using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Data.Enums;

namespace CashierRegister.Domain.DataSeeds
{
    public static class ReceiptSeed
    {
        public static void Seed(CashierRegisterContext dbContext)
        {
            var receiptCount = dbContext.Receipts.Count();
            if (receiptCount != 0) return;

            var cashRegisterWithId = dbContext.CashRegisters.Find(1);
            var cashierWithId = dbContext.Cashiers.Find(1);
            var cashRegisterCount = dbContext.CashRegisterCashiers.Count();
            CashRegisterCashier cashRegisterCashier;
            if (cashRegisterCount == 0)
            {
                 var newCashRegisterCashier = new CashRegisterCashier
                    {
                        Cashier = cashierWithId,
                        CashierId = cashierWithId.Id,
                        CashRegister = cashRegisterWithId,
                        CashRegisterId = cashRegisterWithId.Id,
                        StartOfShift = DateTime.Now
                    };
                    dbContext.Add(newCashRegisterCashier);
                    dbContext.SaveChanges();
                    cashRegisterCashier = newCashRegisterCashier;
            }
            else
            {
                cashRegisterCashier = dbContext.CashRegisterCashiers.First();
            }


            var allProducts = dbContext.Products.ToList();

            for (var receiptIndex = 0; receiptIndex < 10; receiptIndex++)
            {
                var receipt = new Receipt
                {
                    Id = new Guid(),
                    DateTimeCreated = DateTime.Now,
                    CashRegisterCashier = cashRegisterCashier
                };
                dbContext.Add(receipt);

                dbContext.SaveChanges();

                var productsOnReceipt = new List<Product>();

                var productIndexes = new List<int>();
                do
                {
                    var randomIndex = new Random().Next(1, allProducts.Count);
                    var any = productIndexes.Any(index => index == randomIndex);
                    if (!any) productIndexes.Add(randomIndex);
                } while (productIndexes.Count < 3);

                foreach (var productIndex in productIndexes)
                {
                    productsOnReceipt.Add(allProducts[productIndex]);
                }

                var receiptProductList = new List<ReceiptProduct>();

                foreach (var product in productsOnReceipt)
                {
                    var newReceiptProduct = new ReceiptProduct
                    {
                        Product = product,
                        ProductId = product.Id,
                        Receipt = receipt,
                        ReceiptId = receipt.Id,
                        ProductCount = 5,
                        ProductDirectPercentageAtCreation = dbContext.Taxes.Single(tax =>
                                tax.TaxType == TaxType.Direct &&
                                tax.ProductTaxes.Any(prd => prd.ProductId == product.Id))
                            .Percentage,
                        ProductExcisePercentageAtCreation = dbContext.Taxes.Single(tax =>
                                tax.TaxType == TaxType.Excise &&
                                tax.ProductTaxes.Any(prd => prd.ProductId == product.Id))
                            .Percentage,
                        ProductPriceAtCreation = product.Price
                    };

                    receiptProductList.Add(newReceiptProduct);

                    dbContext.ReceiptProducts.Add(newReceiptProduct);
                    dbContext.SaveChanges();

                    product.CountInStorage -= 5;
                    dbContext.SaveChanges();
                }

                var preTaxTotal = receiptProductList.Sum(product => product.Product.Price * product.ProductCount);
                var exciseTotal = receiptProductList.Sum(product =>
                    product.Product.Price *
                    dbContext.Taxes.Single(tax =>
                        tax.TaxType == TaxType.Excise &&
                        tax.ProductTaxes.Any(prd => prd.ProductId == product.Product.Id)).Percentage / 100 *
                    product.ProductCount);
                var directTotal = receiptProductList.Sum(product =>
                    product.Product.Price *
                    dbContext.Taxes.Single(tax =>
                        tax.TaxType == TaxType.Direct &&
                        tax.ProductTaxes.Any(prd => prd.ProductId == product.Product.Id)).Percentage / 100 *
                    product.ProductCount);
                var postTaxTotal = preTaxTotal + exciseTotal + directTotal;

                if (preTaxTotal != null) receipt.PreTaxPriceAtCreation = (int) preTaxTotal;
                if (exciseTotal != null) receipt.ExciseTaxAtCreation = (int) exciseTotal;
                if (directTotal != null) receipt.DirectTaxAtCreation = (int) directTotal;
                if (postTaxTotal != null) receipt.PostTaxPriceAtCreation = (int) postTaxTotal;

                dbContext.SaveChanges();
            }
        }
    }
}
