using FluentValidation;
using FluentValidation.Results;

namespace GameLibrary.Domain.Core
{
    public abstract class Entity<T> : BaseValidator
    {
        protected Entity()
        {
            //ValidationResult = new ValidationResult();
        }

        public int Id { get; protected set; }

    //    public abstract bool IsValid();

      //  public ValidationResult ValidationResult { get; protected set; }
    }
}