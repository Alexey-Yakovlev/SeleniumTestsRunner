using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    internal class DriverSettingsService
    {
        private readonly ISettings _settings;

        public DriverSettingsService(ISettings settings)
        {
            _settings = settings;
        }

        public void SetDriverSettings(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitlyWait(_settings.ImplicitWaitTime);

            driver.Url = _settings.Url;
        }
    }
}