using System;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config
{
    internal interface ISettings
    {
        bool UseLogging { get; }
        bool UseRemoteDriver { get; }
        string Browser { get; }
        string Url { get; }
        string TestFolder { get;}
        TimeSpan ImplicitWaitTime { get; }
    }
}
