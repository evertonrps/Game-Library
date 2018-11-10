using FluentValidation;
using GameLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Games
{
    public class Producer : Entity<Producer>
    {
        public string Name { get; private set; }
        public  DateTime Founded‎ { get; set; }

        public string WebSite { get; private set; }

        public virtual ICollection<Game> Games { get; set; }

        protected Producer() { }
                

        public Producer(string name, DateTime founded, string webSite)
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
                .NotEmpty().WithMessage("Producer name must be provided and must be between 2 and 150 characters")
                .Length(2, 150).WithMessage("Producer name must be provided and must be between 2 and 150 characters");
        }
    }
}
