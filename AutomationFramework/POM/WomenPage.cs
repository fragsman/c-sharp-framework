using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class WomenPage : BasePage
    {
        private readonly By currentPageLink = By.ClassName("woocommerce-breadcrumb");
	    private readonly By title = By.TagName("h1");

        public WomenPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetCurrentPageInNav()
        {
            return Interactor.GetElementText(driver, currentPageLink).Split("/")[1].Trim();
        }

        public string GetPageTitle()
        {
            return Interactor.GetElementText(driver, title);
        }
        
    }
}
