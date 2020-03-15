using AutoMapper;
using GameLibrary.Api.ViewModels;
using GameLibrary.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Api.AutoMapper
{
    public class PlatformMapper : Profile
    {
        public PlatformMapper()
        {
            CreateMap<Platform, PlatformViewModel>();
            CreateMap<PlatformViewModel, Platform>();
        }
    }
}
