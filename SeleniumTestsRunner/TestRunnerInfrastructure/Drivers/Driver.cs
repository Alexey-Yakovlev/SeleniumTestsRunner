using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Browsers;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using SeleniumTestsRunner.TestRunnerInfrastructure.Logging;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    internal class Driver
    {
        private readonly ISettings _settings;

        public Driver(ISettings settings)
        {
            _settings = settings;
        }

        internal IWebDriver CreateDriverForBrowser(Browser.BrowserType browserType)
        {
            IWebDriver driver;
            var driverManager = new DriverManager(_settings);
            if (_settings.UseLogging)
            {
                ILoggingService loggingService = new LoggingService();
                driver = loggingService.EnableLoggingForDriver(driverManager.SelectDriver(browserType));
            }
            else
            {
                driver = driverManager.SelectDriver(browserType);
            }

            var driverSettingsService = new DriverSettingsService(_settings);
            driverSettingsService.SetDriverSettings(driver);

            return driver;
        }

    }
}
