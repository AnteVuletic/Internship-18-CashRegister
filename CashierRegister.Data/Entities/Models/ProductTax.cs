using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Enums;

namespace CashierRegister.Data.Entities.Models
{
    public class ProductTax
    {
        public int ProductTaxId { get; set; }
        public Tax Tax { get; set; }
        public int TaxId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
