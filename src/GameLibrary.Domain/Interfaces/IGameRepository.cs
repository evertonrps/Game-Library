using GameLibrary.Domain.Games;
using System.Collections.Generic;

namespace GameLibrary.Domain.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        IEnumerable<Game> RecuperaGamesCompletos();

        dynamic ObterGameCompletoPorID(int id);
    }
}