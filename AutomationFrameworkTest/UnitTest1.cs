using AutomationFramework.Core;
using AutomationFramework.POM;

namespace AutomationFrameworkTest
{
    public class Tests : BaseTest
    {

        [Test]
        public void StoreLinkLeadsToStorePage()
        {
            driver.Navigate().GoToUrl("https://askomdch.com/");
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickOnSuperiorLink("Store");
            StorePage storePage = new StorePage(driver);
            storePage.GetCurrentPageInNav();
            
            Assert.That(storePage.GetCurrentPageInNav(), Is.EqualTo("StoreXXX"));
        }

        [Test]
        public void MenLinkLeadsToMenPage()
        {
            driver.Navigate().GoToUrl("https://askomdch.com/");
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickOnSuperiorLink("Men");
            StorePage storePage = new StorePage(driver);
            storePage.GetCurrentPageInNav();
            
            Assert.That(storePage.GetCurrentPageInNav(), Is.EqualTo("Men"));
        }

        [Test]
        public void SeleniumActionsTest()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickOnSuperiorLink("Men");
            MenPage menPage = new MenPage(driver);
            menPage.SpecialSearch();

            Assert.That(menPage.GetSearchResultsTitle(), Is.EqualTo("Search results: “Shoes”"), "Verify the first letter is capital");
        }

        [Test]
        public void WomenLinkLeadsToWomenPage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickOnSuperiorLink("Women");
            WomenPage womenPage = new WomenPage(driver);

            Assert.Multiple(() =>
            {
                Assert.That(womenPage.GetPageTitle(), Is.EqualTo("W1men"), "Check that Women page have 'Women' on its title");
                Assert.That(womenPage.GetCurrentPageInNav(), Is.EqualTo("Women"), "Check that Women link leads to a page that contains 'Women' on its navigation tree");
            });
        }
    }
}