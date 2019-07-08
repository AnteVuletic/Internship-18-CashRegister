using System;
using System.Collections.Generic;
using System.Text;
using CashierRegister.Data.Enums;
using Newtonsoft.Json;

namespace CashierRegister.Data.Entities.Models
{
    public class Tax
    {
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("percentage")]
        public int Percentage { get; set; }
        [JsonProperty("taxType")]
        public TaxType TaxType { get; set; }
        public ICollection<ProductTax> ProductTaxes { get; set; }
    }
}
