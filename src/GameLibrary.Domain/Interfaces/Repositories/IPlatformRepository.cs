using GameLibrary.Domain.Entities.Games;
using System.Collections.Generic;

namespace GameLibrary.Domain.Interfaces.Repositories
{
    public interface IPlatformRepository : IRepository<Platform>
    {
        IEnumerable<Platform> GetAll(int gameID);
    }
}