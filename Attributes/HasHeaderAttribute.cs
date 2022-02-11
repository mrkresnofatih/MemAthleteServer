using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MemAthleteServer.Attributes
{
    public class HasHeaderAttribute : Attribute, IActionFilter
    {
        public HasHeaderAttribute(string headerKey)
        {
            _headerKey = headerKey;
        }

        private readonly string _headerKey;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var hasRequiredHeader = context.HttpContext.Request.Headers.ContainsKey(_headerKey);
            if (!hasRequiredHeader)
            {
                throw new Exception(ErrorCodes.BadRequest);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}