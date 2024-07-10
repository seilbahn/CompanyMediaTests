using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class OrganizationsDataBookWindowPageObject
    {
        private IWebDriver _webDriver;

        internal OrganizationsDataBookWindowPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}