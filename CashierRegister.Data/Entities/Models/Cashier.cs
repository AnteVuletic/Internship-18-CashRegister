using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace CashierRegister.Data.Entities.Models
{
    public class Cashier
    {
        public int Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        public ICollection<CashRegisterCashier> Cashiers { get; set; }
    }
}
