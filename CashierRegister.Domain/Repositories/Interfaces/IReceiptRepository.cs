using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface IReceiptRepository
    {
        Receipt CreateReceipt(int cashRegisterCashierId,ICollection<Product> products);
        Receipt ReadReceipt(Guid id);
        bool DeleteReceipt(Guid id);
        IQueryable<Receipt> ReadReceiptByCashRegisterCashierId(int cashRegisterCashierId);
    }
}
