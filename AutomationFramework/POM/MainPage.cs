using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.POM
{
    public class MainPage : BasePage
    {
        private By loc_storeLink = By.XPath("//li[@id='menu-item-1227']/a");
        private By loc_menLink = By.XPath("//li[@id='menu-item-1228']/a");
        private By loc_womenLink = By.XPath("//li[@id='menu-item-1229']/a");

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnSuperiorLink(String name)
        {
            WebElement elem = name switch
            {
                "Store" => (WebElement)Interactor.FindElement(driver, loc_storeLink),
                "Men" => (WebElement)Interactor.FindElement(driver,loc_menLink),
                "Women" => (WebElement)Interactor.FindElement(driver, loc_womenLink),
                _ => null,
            };
            if (elem == null)
                //TODO: Logger.Info("clickOnSuperiorLink: " + name + ", not a valid option");
                Console.Out.WriteLine("clickOnSuperiorLink: " + name + ", not a valid option");
            else
                elem.Click();
        }
    }
}
