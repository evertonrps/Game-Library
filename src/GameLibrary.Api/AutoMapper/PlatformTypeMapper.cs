using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Api.AutoMapper
{
    public class PlatformTypeMapper : Profile
    {
        public PlatformTypeMapper()
        {
            CreateMap<PlatformType, PlatformTypeViewModel>();
            CreateMap<PlatformTypeViewModel, PlatformType>();
        }
    }
}
