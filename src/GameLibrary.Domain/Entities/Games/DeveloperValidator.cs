using FluentValidation;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Entities.Games
{
    public class DeveloperValidator : EntityValidator<Developer>
    {
        public DeveloperValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(Messages.DeveloperNameInvalid)
                .Length(2, 150).WithMessage(Messages.DeveloperNameInvalid);

            RuleFor(c => c.Founded)
            .NotEmpty().WithMessage(Messages.DeveloperFoundedEmpty)
            .GreaterThan(DateTime.MinValue).WithMessage(Messages.DeveloperFoundedInvalid)
            .LessThan(DateTime.Now).WithMessage(Messages.DeveloperFoundedInvalid);
        }
    }
}
