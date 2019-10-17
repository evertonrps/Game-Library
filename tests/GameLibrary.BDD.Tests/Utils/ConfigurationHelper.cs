using Microsoft.Extensions.Configuration;
using System.IO;

namespace GameLibrary.BDD.Tests.Utils
{
    public class ConfigurationHelper
    {
        /*
         using Microsoft.Extensions.Configuration;
         using Microsoft.Extensions.Configuration.FileExtensions;
         using Microsoft.Extensions.Configuration.Json;
             */

        private readonly IConfiguration config;
        public ConfigurationHelper()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

        }

        public static ConfigurationHelper Build()
        {
            return new ConfigurationHelper();
        }
        public  string BaseUrl => config["BaseUrl"];

        public  string HomeUrl => config["HomeUrl"];

        public  string RegisterUrl => string.Format("{0}{1}", BaseUrl, config["RegisterUrl"]);

        public  string LoginUrl => string.Format("{0}{1}", BaseUrl, config["LoginUrl"]);

        public string ChromeDriver => string.Format("{0}", config["ChromeDriver"]);

        public  string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

        public  string FolderPicture => string.Format("{0}{1}", FolderPath, config["FolderPicture"]);
    }
}
