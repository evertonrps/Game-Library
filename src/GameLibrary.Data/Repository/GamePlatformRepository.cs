using GameLibrary.Data.Context;
using GameLibrary.Domain.Games;
using GameLibrary.Domain.Interfaces;
using System.Linq;

namespace GameLibrary.Data.Repository
{
    public class GamePlatformRepository : RepositoryManyToMany<GamePlatform>, IGamePlatformRepository
    {
        private readonly GameLibraryContext _context;
        public IUnitOfWork UnitOfWork;

        public GamePlatformRepository(GameLibraryContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteByGameID(int id)
        {
            var result = _context.Set<GamePlatform>().Where(x => x.GameId == id);
            if (result != null && result.Any())
            {
                _context.RemoveRange(result);
            }
        }
    }
}