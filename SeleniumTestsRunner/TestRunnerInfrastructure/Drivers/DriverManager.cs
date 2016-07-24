using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Browsers;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    internal class DriverManager
    {
        private readonly ISettings _settings;

        public DriverManager(ISettings settings)
        {
            _settings = settings;
        }

        internal IWebDriver SelectDriver(Browser.BrowserType browserType)
        {
            IWebDriver driver;
            var driverServisceManager = new DriverServiceManager(_settings);
            var driverService = driverServisceManager.SelectDriverService();
            switch (browserType)
            {
                default:
                    driver = driverService.GetDriver(browserType.ToString());
                    break;
                case Browser.BrowserType.ReadFromSettings:
                    driver = driverService.GetDriver(_settings.Browser);
                    break;
            }
            return driver;
        }
    }
}