using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class MainMenuPageObject
    {
        private IWebDriver _webDriver;

        public MainMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
