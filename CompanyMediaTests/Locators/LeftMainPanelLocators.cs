using OpenQA.Selenium;

namespace CompanyMediaTests.Locators
{
    internal class LeftMainPanelLocators
    {
        internal static readonly By _userBtn = By.XPath("//a[@href='#login']");
        internal static readonly By _loginInformationLabel = By.XPath("//div[contains(@class, 'gwt-Label') and contains(text(),'Логин:')]");
        internal static readonly By _nameInformationLabel = By.XPath("//div[contains(@class, 'gwt-Label') and contains(text(),'Имя:')]");
        internal static readonly By _surnameInformationLabel = By.XPath("//div[contains(@class, 'gwt-Label') and contains(text(),'Фамилия:')]");
        internal static readonly By _emailInformationLabel = By.XPath("//div[contains(@class, 'gwt-Label') and contains(text(),'EMail:')]");
        internal static readonly By _SystemStructureBtn = By.XPath("//span[text()='Структура Системы']");
        internal static readonly By _OrganizationBtn = By.XPath("//span[text()='Организация']");
        internal static readonly By _OrganizationDataBookBtn = By.XPath("//span[text()='Справочник организаций']");
        internal static readonly By _PersonsDataBookBtn = By.XPath("//span[text()='Справочник персон']");
        internal static readonly By _ClassifiersBtn = By.XPath("//span[text()='Классификаторы']");
        internal static readonly By _AgentsBtn = By.XPath("//span[text()='Агенты']");
        internal static readonly By _ReportsBtn = By.XPath("//span[text()='Отчёты']");
        internal static readonly By _ToolPaletteBtn = By.XPath("//span[text()='Палитра инструментов']");
    }
}