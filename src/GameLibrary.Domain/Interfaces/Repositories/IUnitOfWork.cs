using System.Threading.Tasks;

namespace GameLibrary.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
    }
}