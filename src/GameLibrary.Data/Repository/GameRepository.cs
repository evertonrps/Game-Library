using GameLibrary.Data.Context;
using GameLibrary.Domain.Games;
using GameLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Data.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private readonly GameLibraryContext _context;
        public IUnitOfWork UnitOfWork;

        public GameRepository(GameLibraryContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Game> RecuperaGamesCompletos()
        {
            return _context.Games.Include(c=> c.GamePlatform).ThenInclude(c=> c.Platform).ToList();
        }
    }
}
