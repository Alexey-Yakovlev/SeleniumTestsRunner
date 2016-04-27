using System;
using SeleniumFramework.SeleniumInfrastructure.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal class BrowserService : IBrowserService
    {
        public Browser GetBrowser(Browser.BrowserType browserType)
        {
            return GetBrowser(browserType);
        }     
        
        public IWebDriver GetBrowserForDriver(string browser)
        {
            switch (browser)
            {
                case "Firefox":
                    return new FirefoxDriver();
                case "Chrome":
                    return new ChromeDriver();
                case "PhantomJS":
                    return new PhantomJSDriver();
                default:
                    throw new ArgumentException(browser + "- Not supported browser");
            }
        }       
    }
}
