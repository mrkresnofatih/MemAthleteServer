using AutoMapper;
using MemAthleteServer.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MemAthleteServer.Configs
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Athlete, AthleteCreateUpdateDto>().ReverseMap();
            CreateMap<Food, FoodCreateUpdateDto>().ReverseMap();
            CreateMap<Player, PlayerCreateUpdateDto>().ReverseMap();
            CreateMap<Post, PostCreateUpdateDto>().ReverseMap();
            CreateMap<Comment, CommentCreateUpdateDto>().ReverseMap();
        }
    }

    public static class AutomapperConfig
    {
        public static IMapper CreateIMapper()
        {
            var mapperProfile = new MapperConfiguration(mp => { mp.AddProfile(new AutomapperProfile()); });
            return mapperProfile.CreateMapper();
        }
    }

    public static class AutomapperSetupExtension
    {
        public static void AddAutomapperConfig(this IServiceCollection services)
        {
            services.AddSingleton(AutomapperConfig.CreateIMapper());
        }
    }
}