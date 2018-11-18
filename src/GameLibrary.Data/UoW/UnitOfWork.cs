using GameLibrary.Data.Context;
using GameLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameLibraryContext _context;

        public UnitOfWork(GameLibraryContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
           return  await _context.SaveChangesAsync();
        }
    }
}
