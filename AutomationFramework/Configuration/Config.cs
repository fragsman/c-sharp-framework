namespace AutomationFramework.Configuration
{
    public class Config
    {
        public static string BaseURL { get; set; }

        public static string ExecutionEnvironment { get; set; }

        public static string Username { get; set; }

        public static string Password { get; set; }

        public static BrowserType BrowserType { get; set; }
        public static bool LogToFile { get; set; }
    }
}
