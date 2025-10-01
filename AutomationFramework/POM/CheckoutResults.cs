using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class CheckoutResults : BasePage
    {
        private readonly By checkoutNotice = By.CssSelector("p.woocommerce-notice");
        public CheckoutResults(IWebDriver driver) : base(driver)
        {
        } 
        public string GetCheckoutNotice()
        {
            return Interactor.GetElementText(driver, checkoutNotice);
        }
    }
}
