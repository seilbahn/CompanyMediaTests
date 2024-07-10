using CompanyMediaTests.Locators;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class LogInPagePageObject
    {
        private IWebDriver _webDriver;

        internal LogInPagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        internal MainPagePageObject LogIn(string userName, string password)
        {
            _webDriver.FindElement(LogInPageLocators._userNameInput, true).Click();
            _webDriver.FindElement(LogInPageLocators._userNameInput, true).SendKeys(userName);
            _webDriver.FindElement(LogInPageLocators._passwordInput, true).Click();
            _webDriver.FindElement(LogInPageLocators._passwordInput).SendKeys(password);
            _webDriver.FindElement(LogInPageLocators._logInButton, true).Click();
            
            return new MainPagePageObject(_webDriver);
        }
    }
}