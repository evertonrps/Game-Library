using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Api.ViewModels
{
    public class PlatformViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PlatformTypeId { get; set; }
        public List<GamePlatformViewModel> GamePlatform { get; set; }
    }
}
