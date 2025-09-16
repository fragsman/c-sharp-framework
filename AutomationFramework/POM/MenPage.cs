using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationFramework.POM
{
    public class MenPage : BasePage
    {
        private readonly By searchResultsTitle = By.CssSelector("header h1");
        private readonly By searchBox = By.XPath("//input[@type='search']");
        private readonly By searchButton = By.XPath("//button[contains(text(),'Search')]");

        public MenPage(IWebDriver driver): base(driver)
        {
        }

        public string GetSearchResultsTitle()
        {
            return Interactor.GetElementText(driver, searchResultsTitle);
        }

        public void SpecialSearch()
        {
            IWebElement searchBoxElem = Interactor.FindElement(driver, searchBox);
            Actions actions = new Actions(driver);
            actions.Click(searchBoxElem);
            actions.KeyDown(Keys.Shift);
            actions.SendKeys("s");
            actions.KeyUp(Keys.Shift);
            actions.SendKeys("hoes");
            actions.Perform();
            Search();
        }
        public void Search()
        {
            Interactor.FindElement(driver, searchButton).Click();
        }
    }
}
