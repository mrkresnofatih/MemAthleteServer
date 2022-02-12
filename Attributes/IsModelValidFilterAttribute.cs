using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MemAthleteServer.Attributes
{
    public class IsModelValidFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var isModelValid = context.ModelState.IsValid;
            if (!isModelValid) throw new Exception(ErrorCodes.BadRequest);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}