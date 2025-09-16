namespace AutomationFramework.Utils
{
    internal class Logger
    {

        public static void Debug(string msg)
        {
            Console.WriteLine("[DEBUG] " + msg);
        }

        public static void Info(string msg)
        {
            Console.WriteLine("[INFO] " + msg);
        }

        public static void Error(string msg)
        {
            Console.WriteLine("[ERROR] " + msg);
        }
    }
}
