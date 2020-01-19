using GameLibrary.Data.Context;
using GameLibrary.Domain.Entities.Games;
using GameLibrary.Domain.Interfaces.Repositories;

namespace GameLibrary.Data.Repository
{
    public class PlatformTypeRepository : Repository<PlatformType>, IPlatformTypeRepository
    {
        public PlatformTypeRepository(GameLibraryContext context) : base(context)
        {
        }
    }
}