using GameLibrary.Domain.Core;

namespace GameLibrary.Domain.Games
{
    public class GamePlatform : EntityMany<GamePlatform>
    {
        public GamePlatform()
        {
        }

        public int GameId { get; set; }

        public int PlatformId { get; set; }

        public GamePlatform(int gameID, int platformID)
        {
            GameId = gameID;
            PlatformId = platformID;
        }

        //EF
        public virtual Game Game { get; set; }

        public virtual Platform Platform { get; set; }
    }
}