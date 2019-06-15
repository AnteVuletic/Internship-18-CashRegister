using System;
using System.Collections.Generic;
using System.Text;

namespace CashierRegister.Data.Entities.Models
{
    public class ReceiptProduct
    {
        public Guid ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
