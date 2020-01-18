using GameLibrary.Domain.Entities.Games;

namespace GameLibrary.Domain.Interfaces.Repositories
{
    public interface IGamePlatformRepository : IRepositoryManyToMany<GamePlatform>
    {
        void DeleteByGameID(int id);
    }
}