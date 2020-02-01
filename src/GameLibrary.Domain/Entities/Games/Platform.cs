using FluentValidation;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Core.Resources;
using System;
using System.Collections.Generic;

namespace GameLibrary.Domain.Entities.Games
{
    public class Platform : Entity<Platform>
    {
        public Platform()
        {
        }

        private Platform(string description, int plataformTypeId)
        {
            Description = description;
            PlatformTypeId = plataformTypeId;
        }

        public static Platform Factory(string description, int platformTypeId)
        {
            var platform = new Platform(description, platformTypeId);
            platform.ValidateNow(new PlatformValidator(), platform);
            return platform;
        }

        public string Description { get; private set; }

        public int PlatformTypeId { get; private set; }

        //EF
        public virtual PlatformType PlatFormType { get; private set; }

        public virtual ICollection<GamePlatform> GamePlatform { get; set; }
    }
}