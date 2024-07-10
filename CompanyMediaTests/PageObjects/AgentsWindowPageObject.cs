using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class AgentsWindowPageObject
    {
        private IWebDriver _webDriver;

        internal AgentsWindowPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}