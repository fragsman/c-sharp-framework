using OpenQA.Selenium;
using OpenQA.Selenium.BiDi;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.Utils
{
    internal class Interactor
    {
        private readonly static By overlayBlockers = By.CssSelector("div.blockUI.blockOverlay");
        private readonly static By selectInputSearchBox = By.CssSelector("input.select2-search__field");
        private readonly static By selectResults = By.CssSelector("span.select2-results ul li");

        public static IWebElement FindElement(IWebDriver driver, By locator, int timeout=10)
        {
            IWebElement element = null;
            try
            {
                log("FindElement", driver, locator.ToString());
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
                element = driver.FindElement(locator);
            }
            catch (Exception e)
            {
                Logger.Error("Failed to find element " + locator.ToString());
                Logger.Debug(e.ToString());
            }
            return element;
        }

        public static IList<IWebElement> FindElements(IWebDriver driver, By locator, int timeout=10)
        {
            IList<IWebElement> elements = new List<IWebElement>();
            try
            {
                log("FindElements", driver, locator.ToString());
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                webDriverWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
                elements = driver.FindElements(locator);
            }
            catch (Exception e)
            {
                Logger.Error("Failed to find elements " + locator.ToString());
                Logger.Debug(e.ToString());
            }
            return elements;
        }

        public static void ClickElement(IWebDriver driver, By locator, int timeout=10)
        {
            try
            {
                log("ClickElement", driver, locator.ToString());
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
                driver.FindElement(locator).Click();
            }
            catch (Exception e)
            {
                Logger.Error("Failed to click on element " + locator.ToString());
                Logger.Debug(e.ToString());
            }
        }

        public static void ClickWithJavascript(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click", element);
        }

        public static string GetElementText(IWebDriver driver, By locator, int timeout = 10)
        {
            string elementText = "";
            try
            {
                log("GetElementText", driver, locator.ToString());
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
                elementText = driver.FindElement(locator).Text;
            }
            catch (Exception e)
            {
                Logger.Error("Failed to get text of element " + locator.ToString());
                Logger.Debug(e.ToString());
            }
            return elementText;
        }

        // Wraps the action with an identifier for the WebDriver instance, otherwise it is hard to track in the logs when running tests in parallel
        private static void log(string methodName, IWebDriver driver, string locator)
        {
            string driverId = driver.GetHashCode().ToString();
            Logger.Debug(methodName + ": driver_" + driverId + " " + locator);
        }

        public static void ScrollToElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollToView()", element);
        }

        /*
        The implementation of this will depend on the website.
        In general all select elements withing a same web-page will be exactly the same. So this should work for an entire web-page.
        */
        public static void SelectOption(IWebDriver driver, By locator, string option)
        {
            ClickElement(driver, locator); //Opens the selector, ready to receive text
            IWebElement selectorSearchBox = FindElement(driver, selectInputSearchBox);
            selectorSearchBox.SendKeys(option); //Writes the desired option
            ClickElement(driver, selectResults); //There should be only one option
        }

        public static void SelectNthElement(IWebElement element, int nthElement)
        {
            try
            {
                element.FindElements(By.TagName("li")).ElementAt(nthElement).Click();
            }
            catch (Exception e)
            {
                Logger.Error("There is no such position: " + nthElement + ", " + e);
            }
        }

        /**
        * A BlockingOverlays is basically a loading spinner that prevents the web to be used. This element does not always
        * appear. When it does, it is for less than 2 seconds. Thus, it requires a special treatment.
        */
        public static void WaitForBlockingOverlays(IWebDriver driver)
        {
            IList<IWebElement> elements = new List<IWebElement>();
            try
            {
                log("findOverlays", driver, overlayBlockers.ToString());
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(overlayBlockers));
                elements = driver.FindElements(overlayBlockers);
            }
            catch (Exception e)
            {
                Logger.Error("Failed to find overlays " + overlayBlockers);
                Logger.Debug(e.ToString());
            }
            if (elements.Count > 0)
            {
                Logger.Debug($"Found {elements.Count} overlays, waiting...");
                Thread.Sleep(2000); //TODO Java can check for invisibility of-all-elements (blocking_overlays). Not c#. Research.
            }
        }

        public static IAlert WaitForAlertIsPresent(IWebDriver driver, int timeoutInSeconds = 10)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return Wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public static void AcceptAlert(IWebDriver driver, int timeout = 10)
        {
            IAlert alert = WaitForAlertIsPresent(driver, timeout);
            alert.Accept();
        }

        public static void CancelAlert(IWebDriver driver, int timeout = 10)
        {
            IAlert alert = WaitForAlertIsPresent(driver, timeout);
            alert.Accept();
        }

        public static string GetAlertText(IWebDriver driver, int timeout = 10)
        {
            IAlert alert = WaitForAlertIsPresent(driver, timeout);
            return alert.Text;
        }
    }
}