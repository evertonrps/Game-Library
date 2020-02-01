using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Core
{
    public abstract class EntityValidator<T> : AbstractValidator<T> where T : Entity<T>
    {
    }
}
