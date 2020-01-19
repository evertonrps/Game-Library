using FluentValidation;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Core.Resources;
using System;
using System.Collections.Generic;

namespace GameLibrary.Domain.Entities.Games
{
    public class Developer : Entity<Developer>
    {
        public string Name { get; private set; }
        public DateTime Founded‎ { get; set; }

        public string WebSite { get; private set; }

        public virtual ICollection<Game> Games { get; set; }

        protected Developer()
        {
        }

        public Developer(string name, DateTime founded, string webSite)
        {
            Name = name;
            Founded = founded;
            WebSite = webSite;
        }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateName();
            ValidationResult = Validate(this);
        }

        private void ValidateName()
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