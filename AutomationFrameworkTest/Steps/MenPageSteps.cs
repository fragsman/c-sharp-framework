using AutomationFramework.POM;
using AutomationFrameworkTest.Support;
using Reqnroll;

namespace AutomationFrameworkTest.Steps
{
    [Binding]
    public class MenPageSteps : BaseStep
    {
        public MenPageSteps(MyHooks myHooks) : base(myHooks)
        {
        }

        [Given("user performs a special search for {string}")]
        public void GivenUserPerformsASpecialSearchFor(string textToSearch)
        {
            MenPage menPage = new MenPage(GetDriver());
            menPage.SpecialSearch(textToSearch);
        }

        [Then("user should see in the men search title {string}")]
        public void ThenUserShouldSeeInTheMenSearchTitle(string expectedTitle)
        {
            MenPage menPage = new MenPage(GetDriver());
            Assert.That(menPage.GetCurrentPageInNav(), Is.EqualTo(expectedTitle));
        }

        [Then("user should see in the search results {string}")]
        public void ThenUserShouldSeeInTheSearchResults(string expectedSearchResults)
        {
            MenPage menPage = new MenPage(GetDriver());
            Assert.That(menPage.GetSearchResultsTitle(), Is.EqualTo("Search results: "+expectedSearchResults), "Verify the first letter is capital");
        }
    }
}
