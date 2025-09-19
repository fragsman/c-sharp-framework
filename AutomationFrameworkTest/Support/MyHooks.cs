using AutomationFramework.Configuration;
using AutomationFramework.Core;
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
            //Initialize Logger
        }

        //This will only run run for those scenarios tagged as web as they need a driver and browser
        [BeforeScenario("@web")]
        public void BeforeWebScenario()
        {
            driver = new DriverHandler().CreateWebDriver();
            driver.Navigate().GoToUrl(Config.BaseURL);
            
        }

        //This will only run run for those scenarios tagged as web as they need a driver and browser
        [AfterScenario("@web")]
        public void AfterWebScenario()
        {
            //TestContext.AddResultFile(reportUrl + "dashboard.html");
            //TestContext.AddResultFile(reportUrl + "index.html");
            DriverTeardown();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
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
