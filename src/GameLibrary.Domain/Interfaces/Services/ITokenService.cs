using GameLibrary.Domain.Entities.Token;
using System.Threading.Tasks;

namespace GameLibrary.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        Task<bool> ValidateCredentials(AccessTokenCredentials credenciais);
        Token GenerateToken(AccessTokenCredentials credenciais);
    }
}
