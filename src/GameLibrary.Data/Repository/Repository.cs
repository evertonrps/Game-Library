using GameLibrary.Data.Context;
using GameLibrary.Domain.Core;
using GameLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void Dispose()
        {
            Db.Dispose();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
