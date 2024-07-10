using OpenQA.Selenium;

namespace CompanyMediaTests.Locators
{
    internal class MainPageLocators
    {
        internal static readonly By _userButton = By.XPath("//a[@href='#login']");
        internal static readonly By _loginInformation = By.XPath("(//div[@class='gwt-Label'])[15]");
        internal static readonly By _nameInformation = By.XPath("(//div[@class='gwt-Label'])[16]");
        internal static readonly By _surnameInformation = By.XPath("(//div[@class='gwt-Label'])[17]");
        internal static readonly By _emailInformation = By.XPath("(//div[@class='gwt-Label'])[18]");
    }
}
