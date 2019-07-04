using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CashierRegister.Data.Entities.Models
{
    public class CashRegister
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        public ICollection<CashRegisterCashier> CashRegisterCashiers { get; set; }
    }
}
