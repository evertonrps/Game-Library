using GameLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GameLibrary.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Add(TEntity obj);
        TEntity GetById(int id);        
        void Update(TEntity obj);
        void Delete(int id);
        IEnumerable<TEntity> GetByFunc(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
