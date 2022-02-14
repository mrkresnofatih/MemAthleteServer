using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace MemAthleteServer.Configs
{
    public static class RedisConfig
    {
        public static ConnectionMultiplexer CreateConnectionMultiplexer()
        {
            const string connectionAddress = "localhost:7001,abortConnect=false";
            return ConnectionMultiplexer.Connect(connectionAddress);
        }
    }

    public static class RedisSetupExtension
    {
        public static void AddRedisService(this IServiceCollection services)
        {
            var redis = RedisConfig.CreateConnectionMultiplexer();
            services.AddSingleton(redis.GetDatabase());
        }
    }
}