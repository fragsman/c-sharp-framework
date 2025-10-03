using AutomationFramework.Utils;
using System.Xml.XPath;

namespace AutomationFramework.Configuration
{
    public class ConfigReader
    {
        //Sets static properties from the XML configuration file one time (called in BeforeTestRun in MyHooks.cs)
        public static void SetConfig()
        {
            string envFile = "LocalConfig.xml";
            string env = Environment.GetEnvironmentVariable("ENTORNO");
            if (!string.IsNullOrEmpty(env))
                if(env.Equals("github")) //this is already set in worflow file
                    envFile = "GithubConfig.xml";

            string strFilename = GetProjectDirectory(MyDirectory.AutomationFramework) + "\\Configuration\\"+ envFile;
            Logger.Debug("Reading configuration file: " + strFilename);
            FileStream stream = new FileStream(strFilename, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Set XML Details in the property to be used accross framework
            Config.BaseURL = navigator.SelectSingleNode("AutomationFramework/RunSettings/BaseURL").Value.ToString();
            Config.ExecutionEnvironment = navigator.SelectSingleNode("AutomationFramework/RunSettings/ExecutionEnvironment").Value.ToString();


           Config.Username = navigator.SelectSingleNode("AutomationFramework/RunSettings/Username").Value.ToString();
           Config.Password = navigator.SelectSingleNode("AutomationFramework/RunSettings/Password").Value.ToString();
           string chosenBrowser = navigator.SelectSingleNode("AutomationFramework/RunSettings/Browser").Value.ToString().ToLower();

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
        /// This method return the directory path based on the parameter, it can be the working directory, 
        /// AutomationFramework or AutomationFrameworkTest. The first part depends on the framework installation.
        /// </summary>
        /// <param name="dir">This is directory I want</param>
        /// <returns></returns>
        public static string GetProjectDirectory(MyDirectory dir)
        {
            string workingDirectory = Directory.GetCurrentDirectory();//This is the bin\debug\net8.0 folder of the project from which you run the tests
            if (dir == MyDirectory.Working)
                return Directory.GetParent(workingDirectory).FullName;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string solutionDirectory = Directory.GetParent(projectDirectory).FullName;
            if(dir == MyDirectory.AutomationFrameworkTest)
                solutionDirectory += "\\AutomationFrameworkTest";
            else if (dir == MyDirectory.AutomationFramework)
                solutionDirectory += "\\AutomationFramework";
            return solutionDirectory;
        }
    }
}
