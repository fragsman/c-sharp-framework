using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class HeaderBar : BasePage
    {
        private By cartIcon = By.XPath("//div[@id='ast-desktop-header']//div[@class='ast-cart-menu-wrap']");
        private By cartIconCount = By.XPath("//div[@id='ast-desktop-header']//div[@class='ast-cart-menu-wrap']/span");

        public HeaderBar(IWebDriver driver) : base(driver)
        {
        }
    }
}
