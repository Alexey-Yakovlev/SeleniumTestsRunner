﻿using SeleniumFramework.SeleniumInfrastructure.AppDirectory;
using SeleniumFramework.SeleniumInfrastructure.Browsers;
using SeleniumFramework.SeleniumInfrastructure.Config;

namespace SeleniumFramework.SeleniumInfrastructure.Driver
{
    public class DriverContext
    {
        private static DriverContext _instance;

        private readonly IBrowserService _browserService;

        public Settings Settings;

        private DriverContext(IBrowserService browserService, IAppWorkingDirectoryService appWorkingDirectoryService)
        {
            _browserService = browserService;
            appWorkingDirectoryService.SetCurrentDirectory();
        }

        public static DriverContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    var settings = new Settings();
                    var browserService = new BrowserService(settings);
                    var appWorkingDirectoryService = new AppWorkingDirectoryService(settings.TestFolder);

                    _instance = new DriverContext(browserService, appWorkingDirectoryService);
                }
                return _instance;
            }
        }

        public Browser Browser { get; private set; }

        public Browser SetBrowser(Browser.BrowserType browserType = Browser.BrowserType.ReadFromSettings)
        {
            Browser = _browserService.GetBrowser(browserType);
            return Browser;
        }
    }
}