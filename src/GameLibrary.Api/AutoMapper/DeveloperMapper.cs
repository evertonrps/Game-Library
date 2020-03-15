using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Entities.Games;

namespace GameLibrary.Api.AutoMapper
{
    public class DeveloperMapper : Profile
    {
        public DeveloperMapper()
        {
            CreateMap<Developer, DeveloperViewModel>();
            CreateMap<DeveloperViewModel, Developer>();
        }

    }
}
