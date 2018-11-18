using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Api.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Title { get;  set; }
        public string Description { get; set; }
        public int DeveloperId { get; set; }
    }
}
