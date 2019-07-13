using System;
using System.Collections.Generic;
using System.Text;

namespace CashierRegister.Infrastructure.DataTransferObjects
{
    public class ProductReportDto
    {
        public string Name { get; set; }
        public int ExcisePercentage { get; set; }
        public int ProductDirectPercentage { get; set; }
        public int ProductCount { get; set; }
        public int ProductPrice { get; set; }
    }
}
