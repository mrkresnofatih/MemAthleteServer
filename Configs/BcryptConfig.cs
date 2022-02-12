using MemAthleteServer.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace MemAthleteServer.Configs
{
    public static class BcryptConfig
    {
        public static void AddBcryptUtils(this IServiceCollection services)
        {
            services.AddSingleton<PlayerPasswordHasher>();
        }
    }
}