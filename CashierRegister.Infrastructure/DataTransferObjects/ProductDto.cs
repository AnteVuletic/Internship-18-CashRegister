using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Entities.Models;

namespace CashierRegister.Infrastructure.DataTransferObjects
{
    public class ProductDto
    {
        public Product Product { get; set; }
        public Tax ProductTax { get; set; }
    }
}
