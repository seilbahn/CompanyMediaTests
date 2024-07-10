using OpenQA.Selenium;

namespace CompanyMediaTests.Locators
{
    internal class ReportsWindowLocators
    {
        internal static readonly By _createReportBtn = By.XPath
            ("//a[contains(@class, 'action-bar-button') and contains(text(), 'Создать Отчет')]");
    }
}