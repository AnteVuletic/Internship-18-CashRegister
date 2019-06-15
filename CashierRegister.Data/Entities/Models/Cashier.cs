using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CashierRegister.Data.Entities.Models
{
    public class Cashier
    {
        public int Id { get; set; }
        [MinLength(3),MaxLength(10)]
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<CashRegisterCashier> Cashiers { get; set; }
    }
}
