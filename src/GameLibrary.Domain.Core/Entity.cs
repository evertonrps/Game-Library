using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Core
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public int Id { get; protected set; }

        public abstract bool IsValid();
        public ValidationResult ValidationResult { get; protected set; }
    }
}
