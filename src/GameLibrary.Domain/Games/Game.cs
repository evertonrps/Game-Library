using FluentValidation;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Games
{
    public class Game : Entity<Game>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int DeveloperId { get; private set; }

        private Game()
        {

        }
        public Game(string title, string _description, int _DeveloperId)
        {
            Title = title;
            Description = _description;
            DeveloperId = _DeveloperId;
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
           // ValidateDeveloper();
        }

        //private void ValidateDeveloper()
        //{
        //    if (Developer.IsValid()) return;

        //    foreach (var error in Developer.ValidationResult.Errors)
        //    {
        //        ValidationResult.Errors.Add(error);
        //    }
        //}

        private void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage(Messages.GameTitleInvalid)
                .Length(2, 150).WithMessage(Messages.GameTitleInvalid);
        }

        //EF
        public virtual Developer Developer { get; private set; }

        public virtual ICollection<GamePlatform> GamePlatform { get; set; }
    }
}
