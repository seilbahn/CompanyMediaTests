using OpenQA.Selenium;

namespace CompanyMediaTests.Utility
{
    internal static class IWebElementExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By locator, bool wait = false)
        {
            if (!wait)
            {
                return driver.FindElement(locator);
            }
            else
            {
                WaitUntil.WaitElement(driver, locator);
                return driver.FindElement(locator);
            }
        }
    }
}