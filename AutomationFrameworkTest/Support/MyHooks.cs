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
        private ScenarioContext _scenarioContext;
        private IWebDriver driver;

        public MyHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Initialize reports?
            Logger.ConfigureLogFile();
            Logger.Info("Logfile configured.");
        }

        //This will only run run for those scenarios tagged as web as they need a driver and browser
        [BeforeScenario("@web")]
        public void BeforeWebScenario()
        {
            Logger.Info("Creating web driver...");
            driver = new DriverHandler().CreateWebDriver();
            driver.Navigate().GoToUrl(Config.BaseURL);
            
        }

        //This will only run run for those scenarios tagged as web as they need a driver and browser
        [AfterScenario("@web")]
        public void AfterWebScenario()
        {
            Logger.Info("Closing web driver...");
            //TestContext.AddResultFile(reportUrl + "dashboard.html");
            //TestContext.AddResultFile(reportUrl + "index.html");
            DriverTeardown();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Logger.Info("AfterTestRun...");
            //_extentReports.Flush();
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
    }
}
