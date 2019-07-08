using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Data.Enums;
using CashierRegister.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace CashierRegister.Domain.Repositories.Implementations
{
    public class ReceiptRepository : RepositoryAbstraction, IReceiptRepository
    {
        public ReceiptRepository(CashierRegisterContext cashierRegisterContext) : base(cashierRegisterContext) {}

        public Receipt CreateReceipt(int cashRegisterCashierId,ICollection<Product> products)
        {
            var cashRegisterCashierWithId = _dbCashierRegisterContext.CashRegisterCashiers.Find(cashRegisterCashierId);

            if(cashRegisterCashierWithId == null)
                throw new Exception($"Invalid cash register ID: {cashRegisterCashierId}");

            var id = new Guid();
            var newReceipt = new Receipt
            {
                Id = id,
                CashRegisterCashierId = cashRegisterCashierId,
                CashRegisterCashier = cashRegisterCashierWithId
            };

            _dbCashierRegisterContext.Receipts.Add(newReceipt);
            _dbCashierRegisterContext.SaveChanges();

            foreach (var product in products)
            {
                CreateReceiptProduct(newReceipt.Id, product.Id);
            }

            var allProductsOnReceipt =
                _dbCashierRegisterContext.ReceiptProducts.Where(receiptProducts =>
                    receiptProducts.ReceiptId == newReceipt.Id);

            var preTaxTotal = allProductsOnReceipt.Sum(product => product.Product.Price);
            var exciseTotal = allProductsOnReceipt.Sum(product =>
                product.Product.Price * product.Product.ProductTaxes
                    .Single(productTax => productTax.Tax.TaxType == TaxType.Excise).Tax.Percentage);
            var directTotal = allProductsOnReceipt.Sum(product =>
                product.Product.Price * product.Product.ProductTaxes
                    .Single(productTax => productTax.Tax.TaxType == TaxType.Direct).Tax.Percentage);
            var postTaxTotal = preTaxTotal + exciseTotal + directTotal;

            newReceipt.PreTaxPriceAtCreation = preTaxTotal;
            newReceipt.ExciseTaxAtCreation = exciseTotal;
            newReceipt.DirectTaxAtCreation = directTotal;
            newReceipt.PostTaxPriceAtCreation = postTaxTotal;

            return newReceipt;
        }

        public Receipt ReadReceipt(Guid id)
        {
            var receiptInQuestion = _dbCashierRegisterContext.Receipts.Include(receipt => receipt.ReceiptProducts)
                .ThenInclude(receiptProducts => receiptProducts.Product).FirstOrDefault(receipt => receipt.Id == id);

            if (receiptInQuestion == null)
                throw new Exception($"No receipt with ID: {id}");

            return receiptInQuestion;
        }

        public bool DeleteReceipt(Guid id)
        {
            var receiptInQuestion = ReadReceipt(id);

            _dbCashierRegisterContext.Receipts.Remove(receiptInQuestion);
            _dbCashierRegisterContext.SaveChanges();

            return true;
        }

        public IQueryable<Receipt> ReadReceiptByCashRegisterCashierId(int cashRegisterCashierId)
        {
            var receiptsInQuestion = _dbCashierRegisterContext.Receipts.Where(receipt =>
                receipt.CashRegisterCashierId == cashRegisterCashierId);

            return receiptsInQuestion;
        }
        private void CreateReceiptProduct(Guid receiptId, Guid productId)
        {
            var receiptInQuestion = _dbCashierRegisterContext.Receipts.Find(receiptId);
            var productInQuestion = _dbCashierRegisterContext.Products.Find(productId);

            if (receiptInQuestion == null || productInQuestion == null)
                throw new Exception("Receipt or product not exists");

            var newReceiptProduct = new ReceiptProduct
            {
                Product = productInQuestion,
                ProductId = productId,
                Receipt = receiptInQuestion,
                ReceiptId = receiptId,
                ProductDirectPercentageAtCreation = productInQuestion.ProductTaxes.Single(productTaxes => productTaxes.Tax.TaxType == TaxType.Direct).Tax.Percentage,
                ProductExcisePercentageAtCreation = productInQuestion.ProductTaxes.Single(productTaxes => productTaxes.Tax.TaxType == TaxType.Excise).Tax.Percentage
            };

            _dbCashierRegisterContext.ReceiptProducts.Add(newReceiptProduct);
            _dbCashierRegisterContext.SaveChanges();
        }
    }
}
