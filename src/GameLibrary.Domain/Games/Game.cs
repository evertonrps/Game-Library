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
        public int ProducerId { get; private set; }

        private Game()
        {

        }
        public Game(string title, string _description, int _producerId)
        {
            Title = title;
            Description = _description;
            ProducerId = _producerId;
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
           // ValidateProducer();
        }

        //private void ValidateProducer()
        //{
        //    if (Producer.IsValid()) return;

        //    foreach (var error in Producer.ValidationResult.Errors)
        //    {
        //        ValidationResult.Errors.Add(error);
        //    }
        //}

        private void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Game name must be provided and must be between 2 and 150 characters")
                .Length(2, 150).WithMessage("Game name must be provided and must be between 2 and 150 characters");
        }

        //EF
        public virtual Producer Producer { get; private set; }
    }
}
