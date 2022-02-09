using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MemAthleteServer.Middlewares
{
    public class RequestInOutLogger : IMiddleware
    {
        public RequestInOutLogger(ILogger<RequestInOutLogger> logger)
        {
            _logger = logger;
        }
        
        private readonly ILogger<RequestInOutLogger> _logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("REQUEST-IN");
            await next(context);
            _logger.LogInformation("REQUEST-OUT");
        }
    }
}