using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.AutomatedTests.Utils
{
    public class ConfigurationHelper
    {
        public static string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];

        public static string HomeUrl => ConfigurationManager.AppSettings["HomeUrl"];

        public static string RegisterUrl => string.Format("{0}{1}", BaseUrl, ConfigurationManager.AppSettings["RegisterUrl"]);

        public static string LoginUrl => string.Format("{0}{1}", BaseUrl, ConfigurationManager.AppSettings["LoginUrl"]);

        public static string ChromeDrive => string.Format("{0}", ConfigurationManager.AppSettings["ChromeDrive"]);

        public static string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

        public static string FolderPicture => string.Format("{0}{1}", FolderPath, ConfigurationManager.AppSettings["FolderPicture"]);
    }
}
