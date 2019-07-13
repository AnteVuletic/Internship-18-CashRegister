using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierRegister.Data.Entities.Models;
using CashierRegister.Infrastructure.DataTransferObjects;

namespace CashierRegister.Domain.Repositories.Interfaces
{
    public interface IReceiptRepository
    {
        ReceiptReportDto CreateReceipt(ReceiptDto receiptToCreateDto);
        ICollection<ReceiptReportDto> GetReceiptsByDate(DateTime date);
    }
}
