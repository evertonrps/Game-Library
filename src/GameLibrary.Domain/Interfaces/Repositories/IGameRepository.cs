using GameLibrary.Domain.Entities.Games;
using System.Collections.Generic;

namespace GameLibrary.Domain.Interfaces.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        IEnumerable<Game> RecuperaGamesCompletos();

        dynamic ObterGameCompletoPorID(int id);
    }
}