using OpenQA.Selenium;

namespace AutomationFramework.Utils
{
    internal class Interactor
    {
        public static IWebElement FindElement(IWebDriver driver, By locator)
        {
            return driver.FindElement(locator);
        }
    }
    
}