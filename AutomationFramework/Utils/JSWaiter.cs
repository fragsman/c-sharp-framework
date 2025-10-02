using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class JSWaiter
{
    private static void AjaxComplete(IWebDriver driver)
    {
        IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
        jsExec.ExecuteScript("var callback = arguments[arguments.length - 1];"
            + "var xhr = new XMLHttpRequest();" + "xhr.open('GET', '/Ajax_call', true);"
            + "xhr.onreadystatechange = function() {" + "  if (xhr.readyState == 4) {"
            + "    callback(xhr.responseText);" + "  }" + "};" + "xhr.send();");
    }

    private static void WaitForJQueryLoad(IWebDriver driver)
    {
        IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;

        try
        {
            Boolean jqueryReady = (Boolean)jsExec.ExecuteScript("return jQuery.active==0");
            if (!jqueryReady)
            {
                WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                Wait.Until(wd => ((IJavaScriptExecutor)wd).ExecuteScript("return jQuery.active==0"));
            }
        }
        catch (WebDriverException e)
        {
            Logger.Debug("WaitForJQueryLoad: " + e.Message);
        }
    }

    private static void WaitUntilJQueryReady(IWebDriver driver)
    {
        IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
        Boolean jQueryDefined = (Boolean)jsExec.ExecuteScript("return typeof jQuery != 'undefined'");
        if (jQueryDefined)
        {
            Poll(20);
            WaitForJQueryLoad(driver);
            Poll(20);
        }
    }

    private static void WaitUntilJSReady(IWebDriver driver)
    {
        IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
        try
        {
            Boolean jsReady = jsExec.ExecuteScript("return document.readyState").ToString().Equals("complete");

            if (!jsReady)
            {
                WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                Wait.Until(wd => ((IJavaScriptExecutor)wd).ExecuteScript("return document.readyState").Equals("complete"));
            }
        }
        catch (WebDriverException e)
        {
            Logger.Debug("WaitUntilJSReady: " + e.Message);
        }
    }
    
    private static void WaitUntilAngular5Ready(IWebDriver driver)
    {
        IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
        try
        {
            Object angular5Check = jsExec.ExecuteScript("return getAllAngularRootElements()[0].attributes['ng-version']");
            if (angular5Check != null)
            {
                Boolean angularPageLoaded = (Boolean)jsExec.ExecuteScript("return window.getAllAngularTestabilities().findIndex(x=>!x.isStable()) === -1");
 
                if (!angularPageLoaded)
                {
                    Poll(20);
                    WaitForAngular5Load(driver);
                    Poll(20);
                }
            }
        }
        catch (WebDriverException e)
        {
            Logger.Debug("WaitUntilAngular5Ready: " + e.Message);
        }
    }
    
    private static void WaitForAngular5Load(IWebDriver driver)
    {
        string angularReadyScript = "return window.getAllAngularTestabilities().findIndex(x=>!x.isStable()) === -1";
        AngularLoads(driver, angularReadyScript);
    }

    private static void AngularLoads(IWebDriver driver, string angularReadyScript)
    {
        IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
        try
        {
            bool angularReady = Boolean.Parse(jsExec.ExecuteScript(angularReadyScript).ToString());
            if (!angularReady)
            {
                WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                Wait.Until(wd => ((IJavaScriptExecutor)wd).ExecuteScript(angularReadyScript));
            }
        }
        catch (WebDriverException e)
        {
            Logger.Debug("AngularLoads: " + e.Message);
        }
    }

    public static void WaitAllRequest(IWebDriver driver)
    {
        WaitUntilJSReady(driver);
        AjaxComplete(driver);
        WaitUntilJQueryReady(driver);
        WaitUntilAngular5Ready(driver);
        //WaitUntilAngularReady(); //For oldest Angular prior version 5
    }

    private static void Poll(int milis)
    {
        try
        {
            Thread.Sleep(milis);
        }
        catch (Exception e)
        {
            Logger.Debug(e.Message);
        }
    }

    /*
    private static void WaitForAngularLoad()
    {
        String angularReadyScript = "return angular.element(document).injector().get('$http').pendingRequests.length === 0";
        AngularLoads(angularReadyScript);
    }
    
    private static void WaitUntilAngularReady()
    {
        IJavaScriptExecutor jsExec = (IJavaScriptExecutor)DriverContext.Driver;
        try
        {
            Boolean angularUnDefined = (Boolean)jsExec.ExecuteScript("return window.angular === undefined");
            if (!angularUnDefined)
            {
                Boolean angularInjectorUnDefined = (Boolean)jsExec.ExecuteScript("return angular.element(document).injector() === undefined");
                if (!angularInjectorUnDefined)
                {
                    Poll(20);
                    WaitForAngularLoad();
                    Poll(20);
                }
            }
        }
        catch (WebDriverException e)
        {
            Console.WriteLine("WaitUntilAngularReady: " + e.Message);
        }
    }
    */
}