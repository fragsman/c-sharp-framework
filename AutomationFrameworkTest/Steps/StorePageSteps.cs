using AutomationFramework.POM;
using AutomationFrameworkTest.Support;
using Reqnroll;

namespace AutomationFrameworkTest.Steps
{
    [Binding]
    public class StorePageSteps : BaseStep
    {
        public StorePageSteps(MyHooks myHooks) : base(myHooks)
        {
        }

        [Then("user should see in the store search title {string}")]
        public void ThenUserShouldSeeInTheStoreSearchTitle(string expectedTitle)
        {
            StorePage storePage = new StorePage(GetDriver());
            Assert.That(storePage.GetCurrentPageInNav(), Is.EqualTo(expectedTitle));
        }

        [Given("user selects the first available product")]
        public void GivenUserSelectsTheFirstAvailableProduct()
        {
            StorePage storePage = new StorePage(GetDriver());
            storePage.ClickOnFirstAvailableProduct();
        }
    }
}
