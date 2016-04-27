using SeleniumFramework.SeleniumInfrastructure.Browsers;

namespace SeleniumFramework.SeleniumInfrastructure.Driver
{
    public class DriverContext
    {
        private static DriverContext _instance;
        private DriverContext(IBrowserService browserService)
        {
            _browserService = browserService;
        }

        public static DriverContext Instance
        {
            get { return _instance ?? (_instance = new DriverContext(new BrowserService())); }
        }

        public Browser Browser { get; private set; }

      
        public Browser SetBrowser(Browser.BrowserType browserType)
        {
            Browser = _browserService.GetBrowser(browserType);
            return Browser;
        }

        private readonly IBrowserService _browserService;
    }
}
