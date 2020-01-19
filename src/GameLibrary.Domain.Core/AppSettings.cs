using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Domain.Core
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public double SecurityTokenExpirationMinutesParameter { get; set; }
    }
}
