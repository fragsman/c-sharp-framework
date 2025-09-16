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
                Logger.Debug("FindElement" + locator.ToString());
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
                Logger.Debug("ClickElement" + locator.ToString());
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

        public static String GetElementText(IWebDriver driver, By locator, int timeout = 10)
        {
            String elementText = "";
            try
            {
                Logger.Debug("GetElementText" + locator.ToString());
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
    }
}