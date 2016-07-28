using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using SeleniumTestsRunner.TestRunnerInfrastructure.Drivers;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Browsers
{
    internal class BrowserService : IBrowserService
    {
        private readonly ISettings _settings;

        public BrowserService(ISettings settings)
        {
            _settings = settings;
        }

        public Browser GetBrowser(Browser.BrowserType browserType)
        {
            var driverCreator = new DriverCreator(_settings);
            return new Browser(driverCreator.CreateDriverForBrowser(browserType));
        }
        
    }
}