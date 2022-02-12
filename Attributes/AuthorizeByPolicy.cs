using System;
using System.Collections.Generic;
using MemAthleteServer.Constants;
using MemAthleteServer.SupportEntities;
using MemAthleteServer.Utils;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MemAthleteServer.Attributes
{
    public class AuthorizeByPolicy: Attribute, IActionFilter
    {
        public AuthorizeByPolicy(string appAuthorizationPolicyType)
        {
            _accessTokenUtils = new AccessTokenUtils();
            _authorizationPolicy = GetActiveAuthorizationPolicy(appAuthorizationPolicyType);
        }

        private readonly AuthorizationPolicy _authorizationPolicy;
        private readonly AccessTokenUtils _accessTokenUtils;

        private AuthorizationPolicy GetActiveAuthorizationPolicy(string appAuthorizationPolicyType)
        {
            switch (appAuthorizationPolicyType)
            {
                case AppAuthorizationPolicies.BornInEarly1990s:
                    return new AuthorizationPolicy
                    {
                        PayloadKey = "yearOfBirth",
                        QualificationValues = new List<string>
                            {"1990", "1991", "1992", "1993", "1994"}
                    };
                case AppAuthorizationPolicies.BornInLate1990s:
                    return new AuthorizationPolicy
                    {
                        PayloadKey = "yearOfBirth",
                        QualificationValues = new List<string>
                            {"1995", "1996", "1997", "1998", "1999"}
                    };
                default:
                    return new AuthorizationPolicy
                    {
                        PayloadKey = "yearOfBirth",
                        QualificationValues = new List<string>()
                    };
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var accTokenValue = context.HttpContext.Request.Headers["accToken"];
            var extractedPayloadValue = _accessTokenUtils.GetPayloadByKey(_authorizationPolicy.PayloadKey, accTokenValue);
            var isPolicyRespected = _authorizationPolicy.QualificationValues.Contains(extractedPayloadValue);
            if (!isPolicyRespected)
            {
                throw new Exception(ErrorCodes.InvalidCredential);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}