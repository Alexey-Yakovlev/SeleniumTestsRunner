using OpenQA.Selenium;

namespace SeleniumCustomActions
{
    public static class SeleniumActionsExtensions
    {
        public static void SendKeysExtended(this IWebElement element, string text)
        {
            element.SendKeys(text);
        }
    }
}