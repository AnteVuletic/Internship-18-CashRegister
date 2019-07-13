using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CashierRegister.Data.Entities.Models
{
    public class CashRegisterCashier
    {
        public int Id { get; set; }
        [JsonProperty("cashierId")]
        public int CashierId { get; set; }
        public Cashier Cashier { get; set; }
        [JsonProperty("cashRegisterId")]
        public int CashRegisterId { get; set; }
        public CashRegister CashRegister { get; set; }
        [JsonProperty("startOfShift")]
        public DateTime StartOfShift { get; set; }
        [JsonProperty("endOfShift")]
        public DateTime EndOfShift { get; set; }
    }
}
