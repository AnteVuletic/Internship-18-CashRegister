using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface IReceiptProductRepository
    {
        ReceiptProduct CreateReceiptProduct(Guid receiptId, Guid productId);

    }
}
