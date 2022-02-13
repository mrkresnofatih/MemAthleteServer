using MemAthleteServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MemAthleteServer.DatabaseContexts
{
    public class FacebookDbContext : DbContext
    {
        public FacebookDbContext(DbContextOptions<FacebookDbContext> options) : base(options)
        {
        }
        
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Comment> Comments { get; set; }
    }

    public static class FacebookDbConfig
    {
        public static void AddFacebookDbContext(this IServiceCollection services)
        {
            services.AddDbContext<FacebookDbContext>(
                opt => opt
                    .UseNpgsql(@"Host=localhost;Username=postgres;Password=password;Database=facebookDb"));
        }
    }
}