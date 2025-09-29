using Allure.Net.Commons;
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
            DeletePreviousRunResults();
        }

        //This will only run run for those scenarios tagged as web as they need a driver and browser
        [BeforeScenario("@web")]
        public void OpenBrowserAndNativateToHomepage()
        {
            Logger.Info("Creating web driver...");
            driver = new DriverHandler().CreateWebDriver();
            driver.Navigate().GoToUrl(Config.BaseURL);
            
        }

        //Only Web scenarios might want to take a screenshot in case of failure
        [AfterStep("@web")]
        public void CheckForErrorsAndAddScreenshot()
        {
            if (_scenarioContext.TestError != null)
            {
                Logger.Error("Step failed: " + _scenarioContext.StepContext.StepInfo.Text);
                byte[] screenshotBytes = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
                AllureApi.AddAttachment("Failed Step Screenshot", "image/png", screenshotBytes);
            }
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

        private static void DeletePreviousRunResults()
        {
            string resultsDir = ConfigReader.GetProjectDirectory(MyDirectory.AutomationFrameworkTest) + "\\Reports\\allure-results";
            if (Directory.Exists(resultsDir))
            {
                try
                {
                    Directory.Delete(resultsDir, true);
                    Logger.Info("Previous test results deleted.");
                    Directory.CreateDirectory(resultsDir); //Recreate the directory (but empty)
                }
                catch (IOException ioExp)
                {
                    Logger.Error("Error deleting previous test results: " + ioExp.Message);
                }
            }
        }
    }
}
