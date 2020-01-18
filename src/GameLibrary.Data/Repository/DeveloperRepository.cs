using GameLibrary.Data.Context;
using GameLibrary.Domain.Entities.Games;
using GameLibrary.Domain.Interfaces.Repositories;

namespace GameLibrary.Data.Repository
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(GameLibraryContext context) : base(context)
        {
        }
    }
}