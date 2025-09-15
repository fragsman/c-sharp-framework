using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class StorePage : BasePage
    {
        private By currentPageLink = By.ClassName("woocommerce-breadcrumb");

        public StorePage(IWebDriver driver) : base(driver)
        {
        }

        public String GetCurrentPageInNav()
        {
            return Interactor.FindElement(driver, currentPageLink).Text.Split("/")[1].Trim();
        }
    }
}
