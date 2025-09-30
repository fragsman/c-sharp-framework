using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.Utils
{
    internal class Interactor
    {
        public static IWebElement FindElement(IWebDriver driver, By locator, int timeout=10)
        {
            IWebElement element = null;
            try
            {
                log("FindElement", driver, locator.ToString());
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
                element = driver.FindElement(locator);
            }
            catch (Exception e)
            {
                Logger.Error("Failed to find element " + locator.ToString());
                Logger.Debug(e.ToString());
            }
            return element;
        }

        public static void ClickElement(IWebDriver driver, By locator, int timeout=10)
        {
            try
            {
                log("ClickElement", driver, locator.ToString());
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
                driver.FindElement(locator).Click();
            }
            catch (Exception e)
            {
                Logger.Error("Failed to click on element " + locator.ToString());
                Logger.Debug(e.ToString());
            }
        }

        public static string GetElementText(IWebDriver driver, By locator, int timeout = 10)
        {
            string elementText = "";
            try
            {
                log("GetElementText", driver, locator.ToString());
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
                elementText = driver.FindElement(locator).Text;
            }
            catch (Exception e)
            {
                Logger.Error("Failed to get text of element " + locator.ToString());
                Logger.Debug(e.ToString());
            }
            return elementText;
        }

        // Wraps the action with an identifier for the WebDriver instance, otherwise it is hard to track in the logs when running tests in parallel
        private static void log(string methodName, IWebDriver driver, string locator)
        {
            string driverId = driver.GetHashCode().ToString();
            Logger.Debug(methodName + ": driver_" + driverId + " " + locator);
        }
    }
}