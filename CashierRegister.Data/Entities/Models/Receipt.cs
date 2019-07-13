using System;
using System.Collections.Generic;
using System.Text;

namespace CashierRegister.Data.Entities.Models
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public CashRegisterCashier CashRegisterCashier { get; set; }
        public ICollection<ReceiptProduct> ReceiptProducts { get; set; }
        public int ExciseTaxAtCreation { get; set; }
        public int DirectTaxAtCreation { get; set; }
        public int PreTaxPriceAtCreation { get; set; }
        public int PostTaxPriceAtCreation { get; set; }
    }
}
