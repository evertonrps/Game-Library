using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Entities.Games;

namespace GameLibrary.Api.AutoMapper
{
    public class GameMapper : Profile
    {
        public GameMapper()
        {
            CreateMap<Game, GameViewModel>();

            CreateMap<GameViewModel, Game>()
                .ConvertUsing(x=> Game.Factory(x.Title, x.Description, x.DeveloperId));
        }
    }
}
