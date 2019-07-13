using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Data.Enums;
using CashierRegister.Domain.DataSeeds;
using CashierRegister.Domain.Repositories.Interfaces;
using CashierRegister.Infrastructure.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace CashierRegister.Domain.Repositories.Implementations
{
    public class ReceiptRepository : RepositoryAbstraction, IReceiptRepository
    {
        public ReceiptRepository(CashierRegisterContext cashierRegisterContext) : base(cashierRegisterContext)
        {
            ReceiptSeed.Seed(cashierRegisterContext);
        }

        public ReceiptReportDto CreateReceipt(ReceiptDto receiptDtoToCreate)
        {
            var cashRegisterCashierWithIds = _dbCashierRegisterContext.CashRegisterCashiers
                .Include(cashRegisterCashier => cashRegisterCashier.Cashier)
                .Include(cashRegisterCashier => cashRegisterCashier.CashRegister)
                .Single(shift =>
                        shift.CashRegisterId == receiptDtoToCreate.Receipt.CashRegisterCashier.CashRegisterId &&
                        shift.CashierId == receiptDtoToCreate.Receipt.CashRegisterCashier.CashierId && 
                        shift.EndOfShift == DateTime.MinValue);

            var id = new Guid();
            var newReceipt = new Receipt
            {
                Id = id,
                CashRegisterCashier = cashRegisterCashierWithIds,
                DateTimeCreated = DateTime.Now
            };

            _dbCashierRegisterContext.Receipts.Add(newReceipt);
            _dbCashierRegisterContext.SaveChanges();

            foreach (var product in receiptDtoToCreate.ProductsOnReceipt)
            {
                CreateReceiptProduct(newReceipt.Id, product.Product.Id, (int)product.ProductCount);
            }

            var preTaxTotal = receiptDtoToCreate.ProductsOnReceipt.Sum(product => product.Product.Price * product.ProductCount);
            var exciseTotal = receiptDtoToCreate.ProductsOnReceipt.Sum(product =>
                product.Product.Price *
                _dbCashierRegisterContext.Taxes.Single(tax => tax.TaxType == TaxType.Excise && tax.ProductTaxes.Any(prd => prd.ProductId == product.Product.Id)).Percentage / 100 * 
                product.ProductCount);
            var directTotal = receiptDtoToCreate.ProductsOnReceipt.Sum(product =>
                product.Product.Price *
                _dbCashierRegisterContext.Taxes.Single(tax => tax.TaxType == TaxType.Direct && tax.ProductTaxes.Any(prd => prd.ProductId == product.Product.Id)).Percentage / 100 *
                product.ProductCount);
            var postTaxTotal = preTaxTotal + exciseTotal + directTotal;

            if (preTaxTotal != null) newReceipt.PreTaxPriceAtCreation = (int) preTaxTotal;
            if (exciseTotal != null) newReceipt.ExciseTaxAtCreation = (int) exciseTotal;
            if (directTotal != null) newReceipt.DirectTaxAtCreation = (int) directTotal;
            if (postTaxTotal != null) newReceipt.PostTaxPriceAtCreation = (int) postTaxTotal;

            _dbCashierRegisterContext.SaveChanges();


            var productReportDtoList = new List<ProductReportDto>();
            var productReceipts =
                _dbCashierRegisterContext.ReceiptProducts.Where(receiptProducts =>
                    receiptProducts.ReceiptId == newReceipt.Id);

            foreach (var receiptProduct in productReceipts)
            {
                productReportDtoList.Add(new ProductReportDto
                {
                    Name = receiptProduct.Product.Name,
                    ExcisePercentage = receiptProduct.ProductExcisePercentageAtCreation,
                    ProductDirectPercentage = receiptProduct.ProductDirectPercentageAtCreation,
                    ProductCount = receiptProduct.ProductCount,
                    ProductPrice = receiptProduct.ProductPriceAtCreation
                });
            }

            var receiptReportDto = new ReceiptReportDto
            {
                Receipt = newReceipt,
                ProductReports = productReportDtoList
            };

            return receiptReportDto;
        }

        public ICollection<ReceiptReportDto> GetReceiptsByDate(DateTime date)
        {
            var receiptsDtoOnDate = new List<ReceiptReportDto>();

            var receiptsOnDate =
                _dbCashierRegisterContext.Receipts
                    .Include(receipt => receipt.ReceiptProducts)
                    .ThenInclude(receiptProduct => receiptProduct.Product)
                    .Where(receipt => receipt.DateTimeCreated.Year == date.Year);
            if (date.Month != 0)
            {
                receiptsOnDate = receiptsOnDate.Where(receipt => receipt.DateTimeCreated.Month == date.Month);
                if(date.Day != 0)
                    receiptsOnDate = receiptsOnDate.Where(receipt => receipt.DateTimeCreated.Day == date.Day);
            }

            foreach (var receipt in receiptsOnDate)
            {
                var productReportDtoList = new List<ProductReportDto>();
                foreach (var receiptProduct in receipt.ReceiptProducts)
                {
                    productReportDtoList.Add(new ProductReportDto
                    {
                       Name = receiptProduct.Product.Name,
                       ExcisePercentage = receiptProduct.ProductExcisePercentageAtCreation,
                       ProductDirectPercentage = receiptProduct.ProductDirectPercentageAtCreation,
                       ProductCount = receiptProduct.ProductCount,
                       ProductPrice = receiptProduct.ProductPriceAtCreation
                    });
                }
                receiptsDtoOnDate.Add(new ReceiptReportDto()
                {
                    Receipt = receipt,
                    ProductReports = productReportDtoList
                });
            }

            return receiptsDtoOnDate;
        }

        private void CreateReceiptProduct(Guid receiptId, Guid productId, int productCount)
        {
            var receiptInQuestion = _dbCashierRegisterContext.Receipts.Find(receiptId);
            var productInQuestion = _dbCashierRegisterContext.Products.Single(product => product.Id == productId);

            if (receiptInQuestion == null || productInQuestion == null)
                throw new Exception("Receipt or product not exists");

            if (productInQuestion.CountInStorage < productCount)
                throw new Exception("Product count in storage less then product count.");

            var newReceiptProduct = new ReceiptProduct
            {
                Product = productInQuestion,
                ProductId = productId,
                Receipt = receiptInQuestion,
                ReceiptId = receiptId,
                ProductCount = productCount,
                ProductDirectPercentageAtCreation = _dbCashierRegisterContext.Taxes.Single(tax => tax.TaxType == TaxType.Direct && tax.ProductTaxes.Any(product => product.ProductId == productId)).Percentage,
                ProductExcisePercentageAtCreation = _dbCashierRegisterContext.Taxes.Single(tax => tax.TaxType == TaxType.Excise && tax.ProductTaxes.Any(product => product.ProductId == productId)).Percentage,
                ProductPriceAtCreation = productInQuestion.Price
            };

            _dbCashierRegisterContext.ReceiptProducts.Add(newReceiptProduct);
            _dbCashierRegisterContext.SaveChanges();

            productInQuestion.CountInStorage -= productCount;

            _dbCashierRegisterContext.SaveChanges();
        }
    }
}
