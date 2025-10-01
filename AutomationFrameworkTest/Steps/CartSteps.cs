using AutomationFrameworkTest.Support;
using AutomationFramework.POM;
using Reqnroll;
using NUnit.Framework.Constraints;

namespace AutomationFrameworkTest.Steps
{
    [Binding]
    public class CartSteps : BaseStep
    {
        public CartSteps(MyHooks myHooks) : base(myHooks)
        {
        }

        [Given("user selects proceed to checkout")]
        public void GivenUserSelectsProceedToCheckout()
        {
            CartPage cartPage = new CartPage(GetDriver());
            cartPage.ClickOnProceedToCheckout();
        }

        [When("user enters an invalid coupon code {string}")]
        public void WhenUserEntersAnInvalidCouponCode(string invalidCode)
        {
            CartPage cartPage = new CartPage(GetDriver());
            cartPage.enterCouponCode(invalidCode);
        }

        [Then("coupon error should display {string}")]
        public void ThenCouponErrorShouldDisplayInvalid(string errorMessage)
        {
            CartPage cartPage = new CartPage(GetDriver());
            Assert.That(cartPage.GetCouponErrorResult(),Is.EqualTo(errorMessage));
        }
    }
}
