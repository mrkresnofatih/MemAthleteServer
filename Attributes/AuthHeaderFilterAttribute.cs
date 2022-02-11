using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MemAthleteServer.Attributes
{
    public class AuthHeaderFilterAttribute : Attribute, IAsyncActionFilter
    {
        public AuthHeaderFilterAttribute(string authHeaderValue)
        {
            _authHeaderValue = authHeaderValue;
        }

        private readonly string _authHeaderValue;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isAuthHeaderExists = context.HttpContext.Request.Headers.ContainsKey("auth");
            if (isAuthHeaderExists)
            {
                var authHeaderValue = context.HttpContext.Request.Headers["auth"];
                var isAuthHeaderCorrect = (_authHeaderValue == authHeaderValue);
                if (isAuthHeaderCorrect)
                {
                    await next();
                }
                else
                {
                    throw new Exception(ErrorCodes.InternalError);
                }
            }
            else
            {
                throw new Exception(ErrorCodes.InternalError);
            }
        }
    }
}