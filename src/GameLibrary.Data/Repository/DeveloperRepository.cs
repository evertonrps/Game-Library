using GameLibrary.Data.Context;
using GameLibrary.Domain.Games;
using GameLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Data.Repository
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(GameLibraryContext context) : base(context)
        {

        }
    }
}
