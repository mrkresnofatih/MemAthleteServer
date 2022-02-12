using MemAthleteServer.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace MemAthleteServer.Configs
{
    public static class AuthConfig
    {
        public static void AddAuthUtils(this IServiceCollection services)
        {
            services.AddSingleton<AccessTokenUtils>();
        }
    }
}