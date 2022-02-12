using System;
using System.Collections.Generic;
using JWT;
using JWT.Algorithms;
using JWT.Builder;

namespace MemAthleteServer.Templates
{
    public abstract class JwtTemplate
    {
        protected abstract string GetSecret();

        protected abstract IJwtAlgorithm GetAlgorithm();

        protected abstract IJsonSerializer GetJsonSerializer();

        protected abstract IBase64UrlEncoder GetBase64UrlEncoder();

        private IJwtEncoder GetJwtEncoder()
        {
            return new JwtEncoder(GetAlgorithm(), GetJsonSerializer(), GetBase64UrlEncoder());
        }

        protected string GetToken(Dictionary<string, string> payload)
        {
            var encoder = GetJwtEncoder();
            return encoder.Encode(payload, GetSecret());
        }

        protected Dictionary<string, string> GetPayload(string token)
        {
            return JwtBuilder
                .Create()
                .WithAlgorithm(GetAlgorithm())
                .WithSecret(GetSecret())
                .MustVerifySignature()
                .Decode<Dictionary<string, string>>(token);
        }

        public bool ValidateToken(string token)
        {
            var decoded = GetPayload(token);
            if (decoded != null) return true;
            throw new Exception(ErrorCodes.InvalidCredential);
        }
    }
}