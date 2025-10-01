using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class StorePage : BasePage
    {
        private readonly By currentPageLink = By.ClassName("woocommerce-breadcrumb");
        private readonly By productNames = By.CssSelector("a h2");
        private readonly By products = By.CssSelector(".products img");

        public StorePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetCurrentPageInNav()
        {
            return Interactor.GetElementText(driver, currentPageLink).Split("/")[1].Trim();
        }

        public void ClickOnFirstAvailableProduct()
        {
            IList<IWebElement> productLinks = Interactor.FindElements(driver, products);
            productLinks.ElementAt(0).Click();
        }
    }
}
