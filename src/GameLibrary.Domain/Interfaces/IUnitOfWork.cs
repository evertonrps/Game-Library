using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
