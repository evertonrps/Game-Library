using GameLibrary.Data.Context;
using GameLibrary.Domain.Games;
using GameLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Data.Repository
{
    public class ProducerRepository : Repository<Producer>, IProducerRepository
    {
        public ProducerRepository(GameLibraryContext context) : base(context)
        {

        }
    }
}
