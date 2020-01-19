using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Entities.Games;
using GameLibrary.Domain.Entities.Token;
using GameLibrary.Domain.Entities.Usuario;

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
            CreateMap<AccessTokenCredentials, AccessCredentialsViewModel>();            
        }
    }
}