using FluentValidation;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Games
{
    public class Platform : Entity<Platform>
    {
        public Platform() { }

        public Platform(string description, int plataformTypeId)
        {
            Description = description;
            PlatformTypeId = plataformTypeId;
        }

        public string Description { get; private set; }

        public int PlatformTypeId { get; private set; }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateDescription();
            ValidationResult = Validate(this);
        }

        private void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage(Messages.GameTitleInvalid)
                .Length(2, 150).WithMessage(Messages.GameTitleInvalid);
        }

        //EF 
        public virtual PlatformType PlatFormType { get; private set; }

        public virtual ICollection<GamePlatform> GamePlatform { get; set; }
    }
}
