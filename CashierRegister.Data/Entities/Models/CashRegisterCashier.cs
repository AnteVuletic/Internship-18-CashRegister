using System;
using System.Collections.Generic;
using System.Text;

namespace CashierRegister.Data.Entities.Models
{
    public class CashRegisterCashier
    {
        public int CashierId { get; set; }
        public Cashier Cashier { get; set; }
        public int CashRegisterId { get; set; }
        public CashRegister CashRegister { get; set; }
        public DateTime StartOfShift { get; set; }
        public DateTime EndOfShift { get; set; }
    }
}
