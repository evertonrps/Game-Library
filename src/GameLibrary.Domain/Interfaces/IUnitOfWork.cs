using System.Threading.Tasks;

namespace GameLibrary.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
    }
}