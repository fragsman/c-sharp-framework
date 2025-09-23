using AutomationFrameworkTest.Support;
using Reqnroll;

namespace AutomationFrameworkTest.Steps
{
    [Binding]
    public class ShortSteps_A : BaseStep
    {
        public ShortSteps_A(MyHooks myHooks) : base(myHooks)
        {
        }
    
        [Given("the user {string} inputs its {int}")]
        public void GivenTheUserInputsIts(string username, int age)
        {
            bool allowed = age > 18;
            GetScenarioContext().Add("userAllowed", allowed);
            GetScenarioContext().Add("userName", username);
            GetScenarioContext().Add("userAge", age);
        }

    }
}
