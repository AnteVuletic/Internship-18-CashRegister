using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CashierRegister.Data.Entities.Models;
using Jose;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CashierRegister.Infrastructure.Helpers
{
    public class JwtHelper
    {
        public JwtHelper(IConfiguration configuration)
        {
            _issuer = configuration["JWT:Issuer"];
            _secret = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        }

        private readonly string _issuer;
        private readonly byte[] _secret;

        public string GetJwtToken(Cashier userToGenerateFor)
        {
            var currentSeconds = Math.Round(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            var payload = new Dictionary<string, string>
            {
                {"iss", _issuer},
                {"exp", (currentSeconds + 600).ToString(CultureInfo.InvariantCulture)},
                {"iat", (currentSeconds).ToString(CultureInfo.InvariantCulture)},
                {"cashierId", userToGenerateFor.Id.ToString() }
            };

            return JWT.Encode(payload, _secret, JwsAlgorithm.HS256);
        }
        public int GetUserIdFromToken(string tokenPassed)
        {
            var token = tokenPassed.Replace("Bearer ", "");
            var decodedJObjectToken = (JObject)JsonConvert.DeserializeObject(JWT.Decode(token, _secret));
            var didParsingSucceed = int.TryParse(decodedJObjectToken["cashierId"].ToString(), out int userId);
            if (didParsingSucceed)
                return userId;
            return 0;
        }

        public string GetNewToken(string token)
        {
            var existingToken = token.Replace("Bearer ", "");
            var decodedToken = JWT.Decode(existingToken, _secret);
            var decodedJObjectToken = (JObject)JsonConvert.DeserializeObject(decodedToken);
            var currentSeconds = Math.Round(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            var expiryTime = decodedJObjectToken["exp"].ToObject<double>();

            if (expiryTime - currentSeconds > 600)
                return existingToken;

            var payload = new Dictionary<string, string>
            {
                {"iss", decodedJObjectToken["iss"].ToString() },
                {"exp", (currentSeconds + 600).ToString(CultureInfo.InvariantCulture) },
                {"iat", (currentSeconds).ToString(CultureInfo.InvariantCulture)},
                {"cashierId", decodedJObjectToken["cashierId"].ToString()}
            };

            return JWT.Encode(payload, _secret, JwsAlgorithm.HS256);
        }
    }
}
