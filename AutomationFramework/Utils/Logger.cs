using AutomationFramework.Configuration;
namespace AutomationFramework.Utils
{
    public class Logger
    {
        private static string _logFile;
        public static void Debug(string msg)
        {
            Write("[DEBUG] "+msg);
        }

        public static void Info(string msg)
        {
            Console.WriteLine("[INFO] "+msg);
            Write("[INFO] "+msg);
        }

        public static void Error(string msg)
        {
            Write("[ERROR] "+msg);
        }

        public static void ConfigureLogFile()
        {
            PreviousLogCleanup();
            string filename = "logfile";
            string dir = ConfigReader.GetProjectDirectory(MyDirectory.Working);
            _logFile = dir + "\\"+ filename +".log";
        }

        public static void Write(string logMessage)
        {
            try
            {
                // 'using' block guarantees file to be closed correctly, even if there are errors
                using (StreamWriter writer = new StreamWriter(_logFile,true))
                {
                    writer.WriteLine(GetFormattedMessage(logMessage));
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al escribir en el archivo: {e.Message}");
            }
        }

        private static string GetFormattedMessage(string logMessage)
        {
            return DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "   " + logMessage;
        }

        private static void PreviousLogCleanup()
        {
            try
            {
                if (File.Exists(_logFile))
                    File.Delete(_logFile);
            }
            catch (IOException ioExp)
            {
                // Handle potential I/O errors, such as unauthorized access or file in use
                Console.WriteLine($"PreviousLogCleanup: I/O error: {ioExp.Message}");
            }
            catch (UnauthorizedAccessException uaExp)
            {
                // Handle unauthorized access errors
                Console.WriteLine($"PreviousLogCleanup: Unauthorized access error: {uaExp.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors
                Console.WriteLine($"PreviousLogCleanup: Unexpected error: {ex.Message}");
            }
        }
    }
}
