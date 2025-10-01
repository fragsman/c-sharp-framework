using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class HeaderBar : BasePage
    {
        private readonly By cartIcon = By.XPath("//div[@id='ast-desktop-header']//div[@class='ast-cart-menu-wrap']");
        private readonly By cartIconCount = By.XPath("//div[@id='ast-desktop-header']//div[@class='ast-cart-menu-wrap']/span");

        public HeaderBar(IWebDriver driver) : base(driver)
        {
        }

        public int GetCurrentItemsInCart()
        {
            string cartText = Interactor.GetElementText(driver, cartIconCount);
            cartText.Replace(" ", "");
            return int.Parse(cartText);
        }

        public void EnterToCart()
        {
            driver.Navigate().GoToUrl("https://askomdch.com/cart/");
        }
    }
}
