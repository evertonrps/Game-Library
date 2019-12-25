using GameLibrary.Domain.Games;
using System.Collections.Generic;

namespace GameLibrary.Domain.Interfaces
{
    public interface IPlatformRepository : IRepository<Platform>
    {
        IEnumerable<Platform> GetAll(int gameID);
    }
}