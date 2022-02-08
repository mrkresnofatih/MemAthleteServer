using MemAthleteServer.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace MemAthleteServer.Configs
{
    public static class ShortIdConfig
    {
        public static void AddShortIdGenerator(this IServiceCollection services)
        {
            services.AddSingleton<ShortIdGenerator>();
        }
    }
}