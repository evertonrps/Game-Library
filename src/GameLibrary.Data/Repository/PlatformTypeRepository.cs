using GameLibrary.Data.Context;
using GameLibrary.Domain.Games;
using GameLibrary.Domain.Interfaces;

namespace GameLibrary.Data.Repository
{
    public class PlatformTypeRepository : Repository<PlatformType>, IPlatformTypeRepository
    {
        public PlatformTypeRepository(GameLibraryContext context) : base(context)
        {
        }
    }
}