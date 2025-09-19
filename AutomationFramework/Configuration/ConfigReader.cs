using AutomationFramework.Utils;
using System.Xml.XPath;

namespace AutomationFramework.Configuration
{
    public class ConfigReader
    {
        public static void SetConfig()
        {
            string strFilename = GetProjectDirectory(ProjectType.AutomationFramework) + "\\Configuration\\GlobalConfig.xml";
            Logger.Debug("Reading configuration file: " + strFilename);
            FileStream stream = new FileStream(strFilename, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Set XML Details in the property to be used accross framework
            Config.BaseURL = navigator.SelectSingleNode("AutomationFramework/RunSettings/BaseURL").Value.ToString();
            Config.ExecutionEnvironment = navigator.SelectSingleNode("AutomationFramework/RunSettings/ExecutionEnvironment").Value.ToString();
            Config.IsLog = navigator.SelectSingleNode("AutomationFramework/RunSettings/IsLog").Value.ToString();
            Config.LogPath = navigator.SelectSingleNode("AutomationFramework/RunSettings/LogPath").Value.ToString();

            string chosenBrowser;
            if (Config.ExecutionEnvironment.Equals("local"))
            {
                Config.Username = navigator.SelectSingleNode("AutomationFramework/RunSettings/Username").Value.ToString();
                Config.Password = navigator.SelectSingleNode("AutomationFramework/RunSettings/Password").Value.ToString();
                chosenBrowser = navigator.SelectSingleNode("AutomationFramework/RunSettings/Browser").Value.ToString().ToLower();
            }
            else //Azure (or another CI/CD platform)
            {
                Config.Username = Environment.GetEnvironmentVariable("EY_USER", EnvironmentVariableTarget.User);
                Config.Password = Environment.GetEnvironmentVariable("EY_PASSWORD", EnvironmentVariableTarget.User);
                chosenBrowser = Environment.GetEnvironmentVariable("BROWSER", EnvironmentVariableTarget.User).ToLower();
            }

            switch (chosenBrowser)
            {
                case "edge": Config.BrowserType = BrowserType.Edge; break;
                case "chrome": Config.BrowserType = BrowserType.Chrome; break;
                case "headless": Config.BrowserType = BrowserType.Headless; break;
                case "firefox": Config.BrowserType = BrowserType.FireFox; break;
                default: Logger.Error("Reading configuration file: Invalid browser"); break;
            }
        }

        /// <summary>
        /// Sometimes it depends from which project you run the tests, the current directory will be different.
        /// So I add as a parameter the desired project and I will return the correct path.
        /// Because the only thing that changes is the last folder, the solution folder might be in a different place.
        /// </summary>
        /// <param name="project">This is the ProjectType</param>
        /// <returns></returns>
        public static string GetProjectDirectory(ProjectType project)
        {
            string workingDirectory = Directory.GetCurrentDirectory();//This is the bin\debug\net8.0 folder of the project from which you run the tests
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string solutionDirectory = Directory.GetParent(projectDirectory).FullName;
            if(project == ProjectType.AutomationFrameworkTest)
                solutionDirectory += "\\AutomationFrameworkTest";
            else if (project == ProjectType.AutomationFramework)
                solutionDirectory += "\\AutomationFramework";
            return solutionDirectory;
        }
    }
}
