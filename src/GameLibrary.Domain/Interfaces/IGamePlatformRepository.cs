using GameLibrary.Domain.Games;

namespace GameLibrary.Domain.Interfaces
{
    public interface IGamePlatformRepository : IRepositoryManyToMany<GamePlatform>
    {
        void DeleteByGameID(int id);
    }
}