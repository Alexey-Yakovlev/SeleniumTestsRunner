using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    internal class DriverServiceManager
    {
        private readonly ISettings _settings;

        public DriverServiceManager(ISettings settings)
        {
            _settings = settings;
        }

        internal IDriverService SelectDriverService()
        {
            IDriverService driverService;
            if (_settings.UseRemoteDriver)
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