using AutomationFrameworkTest.Support;
using OpenQA.Selenium;
using Reqnroll;

namespace AutomationFrameworkTest.Steps
{
    public class BaseStep
    {
        private readonly MyHooks myHooks;
        public BaseStep(MyHooks myHooks)
        {
            this.myHooks = myHooks;
        }

        /// <summary>
        /// Returns the WebDriver instance, held in MyHooks class, under [BeforeScenario] hook.
        /// </summary>
        /// <returns></returns>
        public IWebDriver GetDriver()
        {
            return myHooks.GetDriver();
        }

        /// <summary>
        /// Returns a ScenarioContext instance, held in MyHooks class (injected into the Step via Dep.Injection).
        /// This can be used to share data among steps even if they are in different files using Add and Get methods.
        /// </summary>
        /// <returns></returns>
        public ScenarioContext GetScenarioContext()
        {
            return myHooks.GetScenarioContext();
        }
    }
}
