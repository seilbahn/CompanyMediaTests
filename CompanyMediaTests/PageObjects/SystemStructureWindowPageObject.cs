using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class SystemStructureWindowPageObject
    {
        private IWebDriver _webDriver;

        internal SystemStructureWindowPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
