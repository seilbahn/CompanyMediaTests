using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class ReportsWindowPageObject
    {
        private IWebDriver _webDriver;

        internal ReportsWindowPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}