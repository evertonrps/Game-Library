using GameLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
