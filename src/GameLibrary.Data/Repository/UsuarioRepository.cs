using GameLibrary.Data.Context;
using GameLibrary.Domain.Entities.Usuario;
using GameLibrary.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(GameLibraryContext context) : base(context)
        {
        }
    }
}
