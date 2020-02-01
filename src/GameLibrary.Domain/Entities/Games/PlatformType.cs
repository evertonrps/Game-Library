using FluentValidation;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Core.Resources;
using System.Collections.Generic;

namespace GameLibrary.Domain.Entities.Games
{
    public class PlatformType : Entity<PlatformType>
    {
        public PlatformType()
        {
        }

        public PlatformType(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }

        public virtual ICollection<Platform> Platforms { get; set; }
    }
}