using System;
using MemAthleteServer.Utils;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MemAthleteServer.Attributes
{
    public class RequireAuthenticationFilterAttribute : Attribute, IActionFilter
    {
        public RequireAuthenticationFilterAttribute()
        {
            _accessTokenUtils = new AccessTokenUtils();
        }

        private readonly AccessTokenUtils _accessTokenUtils;
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var isAccessTokenHeaderExists = context
                .HttpContext
                .Request
                .Headers
                .ContainsKey("accToken");
            if (!isAccessTokenHeaderExists)
            {
                throw new Exception(ErrorCodes.InvalidCredential);
            }
            var accTokenValue = context.HttpContext.Request.Headers["accToken"];
            var isAccTokenValid = _accessTokenUtils.ValidateToken(accTokenValue);
            if (!isAccTokenValid)
            {
                throw new Exception(ErrorCodes.InvalidCredential);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}