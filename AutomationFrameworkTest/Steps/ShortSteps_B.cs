using AutomationFrameworkTest.Support;
using Reqnroll;

namespace AutomationFrameworkTest.Steps
{
    [Binding]
    public class ShortSteps_B : BaseStep
    {
        public ShortSteps_B(MyHooks myHooks) : base(myHooks)
        {
        }

        [Then("user is allowed to log into the website")]
        public void ThenUserIsAllowedToLogIntoTheWebsite()
        {
            bool allowed = GetScenarioContext().Get<bool>("userAllowed");
            int age = GetScenarioContext().Get<int>("userAge");
            string name = GetScenarioContext().Get<string>("userName");
            NUnitString msg = new($"The user {name} wasn't accepted into the system because it's a minor");
            Assert.That(allowed == true, msg);
        }
    }
}
