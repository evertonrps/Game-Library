using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace GameLibrary.AutomatedTests.Utils
{
    public class ConfigurationHelper
    {
        public static string SiteUrl => ConfigurationManager.AppSettings["SiteUrl"];

        public static string PortalUrl => ConfigurationManager.AppSettings["PortalUrl"];

        public static string HomeUrl => ConfigurationManager.AppSettings["HomeUrl"];

        public static string RegisterUrl => string.Format("{0}{1}", SiteUrl, ConfigurationManager.AppSettings["RegisterUrl"]);

        public static string LoginUrl => string.Format("{0}{1}", SiteUrl, ConfigurationManager.AppSettings["LoginUrl"]);

        public static string ChromeDrive => string.Format("{0}", ConfigurationManager.AppSettings["ChromeDrive"]);

        public static string TestUserName => ConfigurationManager.AppSettings["TestUserName"];

        public static string TestPassword => ConfigurationManager.AppSettings["TestPassword"];

        public static string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

        public static string FolderPicture => string.Format("{0}{1}", FolderPath, ConfigurationManager.AppSettings["FolderPicture"]);
    }
}
