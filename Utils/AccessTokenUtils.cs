using System.Collections.Generic;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using MemAthleteServer.Templates;

namespace MemAthleteServer.Utils
{
    public class AccessTokenUtils : JwtTemplate
    {
        protected override string GetSecret()
        {
            return "VY3kqaoXq7OnTev0znVpvIYv6JAo9XvKpQr5Rt1m";
        }

        protected override IJwtAlgorithm GetAlgorithm()
        {
            return new HMACSHA256Algorithm();
        }

        protected override IJsonSerializer GetJsonSerializer()
        {
            return new JsonNetSerializer();
        }

        protected override IBase64UrlEncoder GetBase64UrlEncoder()
        {
            return new JwtBase64UrlEncoder();
        }

        public string GenerateToken(string playerId, int yearOfBirth)
        {
            var payload = new Dictionary<string, string>
            {
                {"playerId", playerId},
                {"yearOfBirth", yearOfBirth.ToString()}
            };
            return GetToken(payload);
        }

        public string GetPayloadByKey(string key, string token)
        {
            var payload = GetPayload(token);
            var isPayloadKeyExists = payload.ContainsKey(key);
            return isPayloadKeyExists ? payload[key] : null;
        }
    }
}