using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Entities.Games;

namespace GameLibrary.Api.AutoMapper
{
    public class GamePlatformMapper : Profile
    {
        public GamePlatformMapper()
        {
            CreateMap<GamePlatformViewModel, GamePlatform>();
            CreateMap<GamePlatform, GamePlatformViewModel>();
        }
    }
}
