using FluentValidation;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Entities.Games
{
    public class PlatformValidator : EntityValidator<Platform>
    {
        public PlatformValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage(Messages.GameTitleInvalid)
                .Length(2, 150).WithMessage(Messages.GameTitleInvalid);
        }
    }
}
