using GameLibrary.Domain.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Interfaces
{
    public interface IGameRepository :IRepository<Game>
    {
    }
}
