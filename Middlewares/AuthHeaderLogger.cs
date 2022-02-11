using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MemAthleteServer.Middlewares
{
    public class AuthHeaderLogger : IMiddleware
    {
        private readonly ILogger<AuthHeaderLogger> _logger;

        public AuthHeaderLogger(ILogger<AuthHeaderLogger> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Headers.ContainsKey("auth")) _logger.LogWarning("AUTH_REQ");
            await next(context);
        }
    }
}