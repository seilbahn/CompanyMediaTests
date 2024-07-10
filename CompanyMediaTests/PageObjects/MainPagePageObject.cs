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

        internal SystemStructureWindowPageObject OpenSystemStructureWindow()
        {
            _webDriver.FindElement(LeftMainPanelLocators._SystemStructureBtn, true).Click();

            return new SystemStructureWindowPageObject(_webDriver);
        }

        internal OrganizationWindowPageObject OpenOrganizationWindow()
        {
            _webDriver.FindElement(LeftMainPanelLocators._OrganizationBtn, true).Click();

            return new OrganizationWindowPageObject(_webDriver);
        }

        internal OrganizationsDataBookWindowPageObject OpenOrganizationsDataBookWindow()
        {
            _webDriver.FindElement(LeftMainPanelLocators._OrganizationDataBookBtn, true).Click();

            return new OrganizationsDataBookWindowPageObject(_webDriver);
        }

        internal PersonsDataBookWindowPageObject OpenPersonsDataBookWindow()
        {
            _webDriver.FindElement(LeftMainPanelLocators._PersonsDataBookBtn, true).Click();

            return new PersonsDataBookWindowPageObject(_webDriver);
        }

        internal ClassifiersWindowPageObject OpenClassifiersWindow()
        {
            _webDriver.FindElement(LeftMainPanelLocators._ClassifiersBtn, true).Click();

            return new ClassifiersWindowPageObject(_webDriver);
        }

        internal AgentsWindowPageObject OpenAgentsWindow()
        {
            _webDriver.FindElement(LeftMainPanelLocators._AgentsBtn, true).Click();

            return new AgentsWindowPageObject(_webDriver);
        }

        internal ReportsWindowPageObject OpenReportsWindow()
        {
            _webDriver.FindElement(LeftMainPanelLocators._ReportsBtn, true).Click();

            return new ReportsWindowPageObject(_webDriver);
        }

        internal ToolPaletteWindowPageObject OpenToolPaletteWindow()
        {
            _webDriver.FindElement(LeftMainPanelLocators._ToolPaletteBtn, true).Click();

            return new ToolPaletteWindowPageObject(_webDriver);
        }
    }
}