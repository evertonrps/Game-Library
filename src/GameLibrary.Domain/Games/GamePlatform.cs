using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Domain.Games
{
    public class GamePlatform
    {
        public GamePlatform() {  }

        public int GameId { get; set; }

        public int PlatformId { get; set; }

        //EF
        public Game Game { get; set; }
        public Platform Platform { get; set; }
    }
}
