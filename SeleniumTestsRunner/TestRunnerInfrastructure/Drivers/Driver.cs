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
            if (_settings.UseLogging)
            {
                ILoggingService loggingService = new LoggingService();
                driver = loggingService.EnableLoggingForDriver(SelectDriver(browserType));
            }
            else
            {
                driver = SelectDriver(browserType);
            }

            var driverSettingsService = new DriverSettingsService();
            driverSettingsService.SetDriverSettings(driver, _settings);

            return driver;
        }

        private IWebDriver SelectDriver(Browser.BrowserType browserType)
        {
            IWebDriver driver;
            var driverService = SelectDriverService();

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

        private IDriverService SelectDriverService()
        {
            IDriverService driverService;
            if (_settings.UseRemoteBrowser)
            {
                driverService = new RemoteDriverService();
            }
            else
            {
                driverService = new LocalDriverService();
            }
            return driverService;
        }
    }
}
