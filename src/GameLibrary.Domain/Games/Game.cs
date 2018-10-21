using FluentValidation;
using GameLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Games
{
    public class Game : Entity<Game>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public Game(string title, string _description)
        {
            Title = title;
            Description = _description;
        }
        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateTitle();
            ValidationResult = Validate(this);
        }

        private void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Game name must be provided and must be between 2 and 150 characters")
                .Length(2, 150).WithMessage("Game name must be provided and must be between 2 and 150 characters");
        }
    }
}
