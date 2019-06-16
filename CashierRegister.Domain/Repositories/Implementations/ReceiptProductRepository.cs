using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;

namespace CashierRegister.Domain.Repositories.Implementations
{
    public class ReceiptProductRepository : RepositoryAbstraction, IReceiptProductRepository
    {
        public ReceiptProductRepository(CashierRegisterContext cashierRegisterContext) : base(cashierRegisterContext) {}

        public ReceiptProduct CreateReceiptProduct(Guid receiptId, Guid productId)
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
                ReceiptId = receiptId
            };

            _dbCashierRegisterContext.ReceiptProducts.Add(newReceiptProduct);
            _dbCashierRegisterContext.SaveChanges();

            return newReceiptProduct;
        }
    }
}
