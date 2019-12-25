using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Games;

namespace GameLibrary.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Developer, DeveloperViewModel>();
            CreateMap<Game, GameViewModel>();//.ForMember(m=> m.GamePlatform, opt=> opt.MapFrom(src=> src.GamePlatform)).ReverseMap();
            CreateMap<PlatformType, PlatformTypeViewModel>();
            CreateMap<Platform, PlatformViewModel>();
            CreateMap<GamePlatform, GamePlatformViewModel>();
        }
    }
}