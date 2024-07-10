using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class OrganizationWindowPageObject
    {
        private IWebDriver _webDriver;

        internal OrganizationWindowPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
