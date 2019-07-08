using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Infrastructure.DataTransferObjects
{
    public class ReceiptDto
    {
        public int CashRegisterId { get; set; }
        public ICollection<Product> ProductsOnReceipt { get; set; }
    }
}
