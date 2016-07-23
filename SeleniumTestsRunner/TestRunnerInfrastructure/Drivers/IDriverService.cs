using OpenQA.Selenium;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    internal interface IDriverService
    {
        IWebDriver GetDriver(string browser);
    }
}
