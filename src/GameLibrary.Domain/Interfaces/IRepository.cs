using GameLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GameLibrary.Domain.Interfaces
{
    public interface IRepositoryManyToMany<TEntity> : IDisposable where TEntity : EntityMany<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Add(TEntity obj);

        void AddList(IEnumerable<TEntity> obj);

        // TEntity GetById(int id);
        void Update(TEntity obj);

        void Delete(int id);

        IEnumerable<TEntity> GetByFunc(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}