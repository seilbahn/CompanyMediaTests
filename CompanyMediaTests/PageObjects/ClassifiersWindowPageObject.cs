using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class ClassifiersWindowPageObject
    {
        private IWebDriver _webDriver;

        internal ClassifiersWindowPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}