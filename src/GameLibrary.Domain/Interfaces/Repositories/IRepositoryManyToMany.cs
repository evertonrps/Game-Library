using GameLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameLibrary.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Add(TEntity obj);

        TEntity GetById(int id);

        void Update(TEntity obj);

        void Delete(int id);

        IEnumerable<TEntity> GetByFunc(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, string include = null);
        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match, string include = null);

        int SaveChanges();
    }
}