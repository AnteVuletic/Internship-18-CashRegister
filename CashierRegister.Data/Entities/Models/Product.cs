using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CashierRegister.Data.Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("countInStorage")]
        public int CountInStorage { get; set; }
        public ICollection<ReceiptProduct> ReceiptProducts { get; set; }
    }
}
