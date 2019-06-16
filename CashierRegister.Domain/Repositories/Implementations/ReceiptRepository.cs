using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CashierRegister.Domain.Repositories.Implementations
{
    public class ReceiptRepository : RepositoryAbstraction, IReceiptRepository
    {
        public ReceiptRepository(CashierRegisterContext cashierRegisterContext) : base(cashierRegisterContext) {}

        public Receipt CreateReceipt(int cashRegisterCashierId)
        {
            var cashRegisterCashierWithId = _dbCashierRegisterContext.CashRegisterCashiers.Find(cashRegisterCashierId);

            if(cashRegisterCashierWithId == null)
                throw new Exception($"Invalid cash register ID: {cashRegisterCashierId}");

            var newReceipt = new Receipt
            {
                Id = new Guid(),
                CashRegisterCashierId = cashRegisterCashierId,
                CashRegisterCashier = cashRegisterCashierWithId
            };

            _dbCashierRegisterContext.Receipts.Add(newReceipt);
            _dbCashierRegisterContext.SaveChanges();

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
    }
}
