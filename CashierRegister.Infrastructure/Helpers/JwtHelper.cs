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
            _audienceId = configuration["JWT:Issuer"];
            _secret = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        }

        private readonly string _issuer;
        private readonly string _audienceId;
        private readonly byte[] _secret;

        public string GetJwtToken(Cashier userToGenerateFor)
        {
            var currentSeconds = Math.Round(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            var payload = new Dictionary<string, string>
            {
                {"iss", _issuer},
                {"aud", _audienceId},
                {"exp", (currentSeconds + 300).ToString(CultureInfo.InvariantCulture)},
                {"cashierId", userToGenerateFor.Id.ToString() },
                {"username", userToGenerateFor.Username }
            };

            return JWT.Encode(payload, _secret, JwsAlgorithm.HS256);
        }
        public int GetUserIdFromToken(string token)
        {
            var decodedJObjectToken = (JObject)JsonConvert.DeserializeObject(JWT.Decode(token, _secret));
            var didParsingSucceed = int.TryParse(decodedJObjectToken["cashierId"].ToString(), out int userId);
            if (didParsingSucceed)
                return userId;
            return 0;
        }

        public string GetNewToken(string existingToken)
        {
            var decodedToken = JWT.Decode(existingToken, _secret);
            var decodedJObjectToken = (JObject)JsonConvert.DeserializeObject(decodedToken);
            var currentSeconds = Math.Round(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            var expiryTime = decodedJObjectToken["exp"].ToObject<double>();

            if (currentSeconds - expiryTime > 86400)
                return null;

            var payload = new Dictionary<string, string>
            {
                {"iss", decodedJObjectToken["iss"].ToString() },
                {"aud", decodedJObjectToken["aud"].ToString()},
                {"exp", (currentSeconds + 300).ToString(CultureInfo.InvariantCulture) },
                {"cashierId", decodedJObjectToken["cashierId"].ToString()},
                {"username", decodedJObjectToken["username"].ToString()}
            };

            return JWT.Encode(payload, _secret, JwsAlgorithm.HS256);
        }
    }
}
