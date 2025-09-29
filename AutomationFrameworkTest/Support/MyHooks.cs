using AutomationFramework.Configuration;
using AutomationFramework.Core;
using AutomationFramework.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace AutomationFrameworkTest.Support
{
    [Binding]
    public class MyHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        public MyHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Logger.ConfigureLogFile();
            Logger.Info("Logfile configured.");
        }

        //This will only run run for those scenarios tagged as web as they need a driver and browser
        [BeforeScenario("@web")]
        public void OpenBrowserAndNativateToHomepage()
        {
            Logger.Info("Creating web driver...");
            driver = new DriverHandler().CreateWebDriver();
            driver.Navigate().GoToUrl(Config.BaseURL);
            
        }

        //This will only run run for those scenarios tagged as web as they need a driver and browser
        [AfterScenario("@web")]
        public void CloseWebDriver()
        {
            Logger.Info("Closing web driver...");
            DriverTeardown();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void DriverTeardown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public ScenarioContext GetScenarioContext()
        {
            return _scenarioContext;
        }
    }
}
