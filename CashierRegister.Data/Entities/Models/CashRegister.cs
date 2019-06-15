using System;
using System.Collections.Generic;
using System.Text;

namespace CashierRegister.Data.Entities.Models
{
    public class CashRegister
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public ICollection<CashRegisterCashier> CashRegisterCashiers { get; set; }
    }
}
