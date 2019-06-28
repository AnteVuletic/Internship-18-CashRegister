using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CashierRegister.Infrastructure.DataTransferObjects
{
    public class CashierDto
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
