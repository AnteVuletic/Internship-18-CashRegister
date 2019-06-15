using System;
using System.Collections.Generic;
using System.Text;

namespace CashierRegister.Data.Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CountInStorage { get; set; }
        public ICollection<ReceiptProduct> ReceiptProducts { get; set; }
    }
}
