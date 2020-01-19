using GameLibrary.Data.Context;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameLibrary.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected GameLibraryContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(GameLibraryContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            DbSet.Add(obj);
            return obj;
        }

        public virtual void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, string include = null)
        {
            try
            {
                if (string.IsNullOrEmpty(include))
                    return await DbSet.SingleOrDefaultAsync(match);
                else
                //Include
                {
                    var args = include.Split(',');
                    TEntity entidade = null;
                    foreach (var item in args)
                    {
                        if (!string.IsNullOrEmpty(item.Trim()))
                        {
                            entidade = await DbSet.Include(item.Trim()).SingleOrDefaultAsync(match);
                        }
                    }
                    return entidade;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetByFunc(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

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