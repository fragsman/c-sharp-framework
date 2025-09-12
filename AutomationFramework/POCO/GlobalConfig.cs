using AutomationFramework.Core;

namespace AutomationFramework.Config
{
    public class GlobalConfig
    {
        public static string AUT { get; set; }

        public static string ExecutionEnvironment { get; set; }

        public static string Username { get; set; }

        public static string Password { get; set; }

        public static BrowserType BrowserType { get; set; }

        public static string IsLog { get; set; }

        public static string LogPath { get; set; }
    }
}
