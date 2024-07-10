using OpenQA.Selenium;

namespace CompanyMediaTests.Locators
{
    internal class LogInPageLocators
    {
        internal static readonly By _userNameInput = By.XPath("//input[@name='username']");
        internal static readonly By _passwordInput = By.XPath("//input[@name='userpassword']");
        internal static readonly By _logInButton = By.XPath("//div[@class='darkButton']");
    }
}