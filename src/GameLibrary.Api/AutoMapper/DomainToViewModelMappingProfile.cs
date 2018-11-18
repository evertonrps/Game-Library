using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Developer, DeveloperViewModel>();
            CreateMap<Game, GameViewModel>();
        }
    }
}
