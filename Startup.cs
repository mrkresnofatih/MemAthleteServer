using MemAthleteServer.Configs;
using MemAthleteServer.DatabaseContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MemAthleteServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(opt => { opt.SuppressModelStateInvalidFilter = true; });
            services.AddFacebookDbContext();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "MemAthleteServer", Version = "v1"});
            });

            services.AddAutomapperConfig();
            services.AddRepositories();
            services.AddShortIdGenerator();
            services.AddMiddlewaresTransient();
            services.AddRedisService();
            services.AddBcryptUtils();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //dev
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MemAthleteServer v1"));
            }

            app.UseAppExceptionHandler(); //c

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAppMiddlewares(); //c

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}