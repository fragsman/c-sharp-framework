using AutomationFramework.POM;
using AutomationFrameworkTest.Support;
using Reqnroll;

namespace AutomationFrameworkTest.Steps
{
    [Binding]
    public class WomenPageSteps : BaseStep
    {
        public WomenPageSteps(MyHooks myHooks) : base(myHooks)
        {
        }

        [Then("user should see in {string} in page title and {string} in current navigation page")]
        public void ThenUserShouldSeeInInPageTitleAndInCurrentNavigationPage(string expectedPageTitle, string expectedNavPage)
        {
            WomenPage womenPage = new WomenPage(GetDriver());

            Assert.Multiple(() =>
            {
                Assert.That(womenPage.GetPageTitle(), Is.EqualTo(expectedPageTitle), "Check that Women page have 'Women' on its title");
                Assert.That(womenPage.GetCurrentPageInNav(), Is.EqualTo(expectedNavPage), "Check that Women link leads to a page that contains 'Women' on its navigation tree");
            });
        }
    }
}
