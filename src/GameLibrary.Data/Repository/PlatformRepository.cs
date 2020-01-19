using GameLibrary.Data.Context;
using GameLibrary.Domain.Entities.Games;
using GameLibrary.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Data.Repository
{
    public class PlatformRepository : Repository<Platform>, IPlatformRepository
    {
        private readonly GameLibraryContext _context;
        public IUnitOfWork UnitOfWork;

        public PlatformRepository(GameLibraryContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Platform> GetAll(int gameID)
        {
            return _context.Platforms.Include(c => c.GamePlatform).Include(c => c.PlatFormType).Where(x => x.Id == gameID).ToList();
        }
    }
}