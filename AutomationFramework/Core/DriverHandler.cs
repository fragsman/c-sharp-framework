using AutomationFramework.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationFramework.Core
{
    public class DriverHandler
    {
        public IWebDriver CreateWebDriver()
        {
            WebDriver driver;
            ConfigReader.SetConfig();
            BrowserType browserType = Config.BrowserType;
            switch (browserType)
            {
                case BrowserType.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    driver.Manage().Window.Maximize();
                    break;

                case BrowserType.FireFox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;

                case BrowserType.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;

                case BrowserType.Headless: //TODO: not tested yet
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--headless");
                    chromeOptions.AddArgument("--no-sandbox");
                    chromeOptions.AddArgument("--disable-extensions");
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddArgument("--disable-gpu");
                    chromeOptions.AddArgument("--ignore-certificate-errors");
                    chromeOptions.AcceptInsecureCertificates = true;
                    driver = new ChromeDriver(chromeOptions);
                    break;
                default:
                    throw new Exception("Invalid Browser");
            }
            return driver;
        }
    }
}
