using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class MainPagePageObject
    {
        private IWebDriver _webDriver;

        internal MainPagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
