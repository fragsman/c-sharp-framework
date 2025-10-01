using AutomationFramework.POM;
using AutomationFrameworkTest.Support;
using Reqnroll;

namespace AutomationFrameworkTest.Steps
{
    [Binding]
    public class CheckoutResultsStep : BaseStep
    {
        public CheckoutResultsStep(MyHooks myHooks) : base(myHooks)
        {
        }

        [Then("checkout notice should display {string}")]
        public void ThenCheckoutNoticeShouldDisplay(string expectedMsg)
        {
            CheckoutResults checkoutResults = new CheckoutResults(GetDriver());
            Assert.That(checkoutResults.GetCheckoutNotice(), Is.EqualTo(expectedMsg));
        }
    }
}
