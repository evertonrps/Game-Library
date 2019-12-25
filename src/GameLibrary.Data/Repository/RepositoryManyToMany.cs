using GameLibrary.Data.Context;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GameLibrary.Data.Repository
{
    public abstract class RepositoryManyToMany<TEntity> : IRepositoryManyToMany<TEntity> where TEntity : EntityMany<TEntity>
    {
        protected GameLibraryContext Db;
        protected DbSet<TEntity> DbSet;

        protected RepositoryManyToMany(GameLibraryContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            DbSet.Add(obj);
            return obj;
        }

        public virtual void AddList(IEnumerable<TEntity> obj)
        {
            DbSet.AddRange(obj);
        }

        public virtual void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetByFunc(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        //public virtual TEntity GetById(int id)
        //{
        //    return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        //}

        public virtual int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
    }
}