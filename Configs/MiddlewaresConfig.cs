using MemAthleteServer.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MemAthleteServer.Configs
{
    public static class MiddlewaresConfig
    {
        public static void AddMiddlewaresTransient(this IServiceCollection services)
        {
            services.AddTransient<RequestInOutLogger>();
            services.AddTransient<AuthHeaderLogger>();
        }

        public static void UseAppMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestInOutLogger>();
            app.UseMiddleware<AuthHeaderLogger>();
        }
    }
}