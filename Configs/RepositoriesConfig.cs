using MemAthleteServer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MemAthleteServer.Configs
{
    public static class RepositoriesConfig
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<AthleteRepository>();
            services.AddSingleton<FoodRepository>();
        }
    }
}