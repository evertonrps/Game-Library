using GameLibrary.Data.Context;
using GameLibrary.Domain.Games;
using GameLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Data.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(GameLibraryContext context) : base(context)
        {

        }
    }
}
