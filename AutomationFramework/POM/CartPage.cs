using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class CartPage : BasePage
    {
        private readonly By proceedToCheckoutBtn = By.CssSelector("div.wc-proceed-to-checkout > a");
        private readonly By couponCodeInput = By.Id("coupon_code");
        private readonly By couponCodeBtn = By.Name("apply_coupon");
        private readonly By couponErrorMsg = By.CssSelector("ul.woocommerce-error li");

        public CartPage(IWebDriver driver) : base(driver)
        {
        }
        public void ClickOnProceedToCheckout()
        {
            Interactor.ClickElement(driver, proceedToCheckoutBtn);
        }

        public void enterCouponCode(String code)
        {
            Interactor.FindElement(driver, couponCodeInput).SendKeys(code);
            Interactor.ClickElement(driver, couponCodeBtn);
            WaitForBlockingOverlays();
        }

        public string GetCouponErrorResult()
        {
            return Interactor.GetElementText(driver, couponErrorMsg);
        }
    }
}
