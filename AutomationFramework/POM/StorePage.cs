using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class StorePage : BasePage
    {
        private readonly By currentPageLink = By.ClassName("woocommerce-breadcrumb");

        public StorePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetCurrentPageInNav()
        {
            return Interactor.GetElementText(driver, currentPageLink).Split("/")[1].Trim();
        }
    }
}
