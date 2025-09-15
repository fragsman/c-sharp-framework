using AutomationFramework.Core;
using AutomationFramework.POM;

namespace AutomationFrameworkTest
{
    public class Tests : BaseTest
    {

        [Test]
        public void SeleniumTest()
        {
            driver.Navigate().GoToUrl("https://askomdch.com/");
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickOnSuperiorLink("Store");
            StorePage storePage = new StorePage(driver);
            storePage.GetCurrentPageInNav();
            Assert.That(storePage.GetCurrentPageInNav(), Is.EqualTo("Store"));
        }

        [Test]
        public void Test2()
        {
            Assert.That("Fede", Is.EqualTo("Camila"));
        }

        [Test]
        public void Test3()
        {
            int expected = 42;
            int sum = 40 + 2;
            Assert.That(sum, Is.EqualTo(expected));
        }
    }
}