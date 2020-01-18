using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Entities.Games;

namespace GameLibrary.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<DeveloperViewModel, Developer>();
            CreateMap<GameViewModel, Game>()
                .ConstructUsing(x => new Game(x.Title, x.Description, x.DeveloperId));
            CreateMap<PlatformTypeViewModel, PlatformType>();
            CreateMap<PlatformViewModel, Platform>();
            CreateMap<GamePlatformViewModel, GamePlatform>().
                ConstructUsing(x => new GamePlatform(x.GameId, x.PlatformId));
        }
    }
}