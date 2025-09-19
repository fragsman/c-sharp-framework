using AutomationFramework.POM;
using AutomationFrameworkTest.Support;
using Reqnroll;

namespace AutomationFrameworkTest.Steps
{
    [Binding]
    public class MainPageSteps : BaseStep
    {
        public MainPageSteps(MyHooks myHooks) : base(myHooks)
        {
        }

        [Given("user selects the {string} link")]
        public void UserSelectsTheLink(string linkName)
        {
            MainPage mainPage = new MainPage(GetDriver());
            mainPage.ClickOnSuperiorLink(linkName);
        }
    }
}
