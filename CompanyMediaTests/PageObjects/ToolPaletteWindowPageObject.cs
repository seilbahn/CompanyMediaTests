using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class ToolPaletteWindowPageObject
    {
        private IWebDriver _webDriver;

        internal ToolPaletteWindowPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}