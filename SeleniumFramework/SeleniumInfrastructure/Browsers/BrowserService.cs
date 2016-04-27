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
            IWebDriver driver = null;
            switch (browserType)
            {
                case Browser.BrowserType.Firefox:
                case Browser.BrowserType.Chrome:
                    driver = GetBrowserForDriver(browserType.ToString());
                    break;
                case Browser.BrowserType.ReadFromAppConfig:
                    driver = GetBrowserForDriver(Settings.Browser);
                    break;
                default:
                    throw new ArgumentException("Browser type invalid");
            }

            return new Browser(driver);
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
