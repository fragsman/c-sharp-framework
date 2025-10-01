using AutomationFramework.POCO;
using AutomationFramework.POM;
using AutomationFramework.Utils;
using AutomationFrameworkTest.Support;
using Reqnroll;

namespace AutomationFrameworkTest.Steps
{
    [Binding]
    public class CheckoutSteps : BaseStep
    {
        public CheckoutSteps(MyHooks myHooks) : base(myHooks)
        {
        }

        [When("user sets the billing address")]
        public void WhenUserSetsTheBillingAddress()
        {
            BillingAddress billingAddress = JSONHelper.DeserializeFromFile<BillingAddress>("\\TestData\\billingAddress.json");
            CheckoutPage checkoutPage = new CheckoutPage(GetDriver());
            checkoutPage.SetBillingAddress(billingAddress);
        }

        [When("user places the order")]
        public void WhenUserPlacesTheOrder()
        {
            CheckoutPage checkoutPage = new CheckoutPage(GetDriver());
            checkoutPage.PlaceOrder();
        }

        [When("user selects the country in position {int}")]
        public void WhenUserSelectsTheCountryInPosition(int position)
        {
            CheckoutPage checkoutPage = new CheckoutPage(GetDriver());
            checkoutPage.SelectNthCountry(position);
        }

        [Then("country selected in checkout should be {string}")]
        public void ThenCountrySelectedInCheckoutShouldBe(string expectedCountry)
        {
            CheckoutPage checkoutPage = new CheckoutPage(GetDriver());
            String currentCountry = checkoutPage.GetCurrentSelectedCountry();
            Assert.That(currentCountry== expectedCountry, "selected country does not match the expected:");
        }
    }
}
