using FluentValidation;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Games
{
    public class PlatformType : Entity<PlatformType>
    {
        protected PlatformType(){}

        public PlatformType(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }

        public virtual ICollection<Platform> Platforms { get; set; }
        

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
    }
}
