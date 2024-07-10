using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class PersonsDataBookWindowPageObject
    {
        private IWebDriver _webDriver;

        internal PersonsDataBookWindowPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}