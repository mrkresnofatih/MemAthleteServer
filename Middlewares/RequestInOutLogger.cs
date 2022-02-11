using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MemAthleteServer.Middlewares
{
    public class RequestInOutLogger : IMiddleware
    {
        private readonly ILogger<RequestInOutLogger> _logger;

        public RequestInOutLogger(ILogger<RequestInOutLogger> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("REQUEST-IN");
            await next(context);
            _logger.LogInformation("REQUEST-OUT");
        }
    }
}