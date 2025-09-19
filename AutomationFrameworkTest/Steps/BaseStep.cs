using AutomationFrameworkTest.Support;
using OpenQA.Selenium;

namespace AutomationFrameworkTest.Steps
{
    public class BaseStep
    {
        MyHooks myHooks;
        public BaseStep(MyHooks myHooks)
        {
            this.myHooks = myHooks;
        }

        public IWebDriver GetDriver()
        {
            return myHooks.GetDriver();
        }
    }
}
