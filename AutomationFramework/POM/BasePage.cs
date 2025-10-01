using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class BasePage
    {
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForBlockingOverlays()
        {
            Interactor.WaitForBlockingOverlays(driver);
        }
    }
}
