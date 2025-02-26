﻿using CompanyMediaTests.Locators;
using CompanyMediaTests.TestData;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CompanyMediaTests.PageObjects
{
    internal class SSWinPageObject
    {
        private IWebDriver _webDriver;

        internal SSWinPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        internal SSWinPageObject OpenApps()
        {
            _webDriver.FindElement(LeftMainPanelLocators._SystemStructureBtn, true).Click();
            //_webDriver.FindElement(LeftMainPanelLocators._PinBtn, true).Click();
            //IWebElement element = _webDriver.FindElement(SSWinLocators._appsBtn, true);            
            //((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].click();", element);
            _webDriver.FindElement(SSWinLocators._appsBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject OpenOrgsApps()
        {
            _webDriver.FindElement(LeftMainPanelLocators._SystemStructureBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._orgsAppsBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject CreateApp(SSWinAppsTestData testData)
        {
            _webDriver.FindElement(SSWinLocators._createBtn, true).Click();

            _webDriver.FindElement(SSWinLocators._typeDropDownList, true).Click();
            _webDriver.FindElement(SSWinLocators._typeDropDownList, true).Click();
            string xpath = $"//td[text()='{testData.Type}']";
            _webDriver.FindElement(By.XPath(xpath)).Click();

            _webDriver.FindElement(SSWinLocators._nameInput, true).Click();
            _webDriver.FindElement(SSWinLocators._nameInput, true).SendKeys(testData.Name);

            if (_webDriver.FindElement(SSWinLocators._nonSysModuleChkBox, true).Selected)
            {
                _webDriver.FindElement(SSWinLocators._nonSysModuleChkBox, true).Click();
            }

            if (testData.NonSysModule)
            {
                _webDriver.FindElement(SSWinLocators._nonSysModuleChkBox, true).Click();
            }

            _webDriver.FindElement(SSWinLocators._basicModuleTypeDropDownList, true).Click();
            xpath = $"//td[text()='{testData.BasicModuleType}']";
            _webDriver.FindElement(By.XPath(xpath), true).Click();

            _webDriver.FindElement(SSWinLocators._packageInput, true).Click();
            _webDriver.FindElement(SSWinLocators._packageInput, true).Clear();
            _webDriver.FindElement(SSWinLocators._packageInput, true).SendKeys(testData.PackageName);

            _webDriver.FindElement(SSWinLocators._protocolAppDropDownList, true).Click();
            xpath = $"//td[text()='{testData.ProtocolApplication}']";
            _webDriver.FindElement(By.XPath(xpath), true).Click();

            _webDriver.FindElement(SSWinLocators._projectsAppDropDownList, true).Click();
            xpath = $"//td[text()='{testData.ProjectsApplication}']";
            _webDriver.FindElement(By.XPath(xpath), true).Click();

            _webDriver.FindElement(SSWinLocators._fileNameInput).Click();
            _webDriver.FindElement(SSWinLocators._fileNameInput).Clear();
            _webDriver.FindElement(SSWinLocators._fileNameInput).SendKeys(testData.FileName);

            if (_webDriver.FindElement(SSWinLocators._namedAppChkBox, true).Selected)
            {
                _webDriver.FindElement(SSWinLocators._namedAppChkBox, true).Click();
            }

            if (testData.NamedApp)
            {
                _webDriver.FindElement(SSWinLocators._namedAppChkBox, true).Click();
            }

            _webDriver.FindElement(SSWinLocators._storageDropDownList, true).Click();
            xpath = $"//td[text()='{testData.Storage}']";
            _webDriver.FindElement(By.XPath(xpath), true).Click();

            _webDriver.FindElement(SSWinLocators._saveAndCloseBtn).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject CreateOrgsApps(SSWinOrgsAppsTestData testData)
        {
            // Sometimes it helps:
            // IWebElement element = _webDriver.FindElement(SSWinLocators._applicationSearchBoxInput, true);
            // Actions actions = new Actions(_webDriver);
            // actions.MoveToElement(element).SendKeys(Keys.Enter).Perform(); 

            _webDriver.FindElement(SSWinLocators._createBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._organizationInput, true).Click();
            _webDriver.FindElement(SSWinLocators._organizationInput, true).SendKeys(testData.Organization);
            string xpath = $"//td[text()='{testData.Organization}']";
            _webDriver.FindElement(By.XPath(xpath), true).Click();
            _webDriver.FindElement(SSWinLocators._applicationInput, true).Click();
            _webDriver.FindElement(SSWinLocators._applicationInput, true).SendKeys(testData.App);
            xpath = $"//td[contains (text(), '{testData.App}')]";
            _webDriver.FindElement(By.XPath(xpath), true).Click();
            _webDriver.FindElement(SSWinLocators._saveAndCloseBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject DeleteOrgsApp(SSWinOrgsAppsTestData testData)
        {
            _webDriver.FindElement(SSWinLocators._applicationSearchBoxInput, true).Click();
            _webDriver.FindElement(SSWinLocators._applicationSearchBoxInput, true).Clear();
            _webDriver.FindElement(SSWinLocators._applicationSearchBoxInput, true).SendKeys(testData.App);
            try
            {
                _webDriver.FindElement(SSWinLocators._applicationSearchBoxInput, true).SendKeys(Keys.Enter);
            }
            catch (StaleElementReferenceException ex)
            {
                IWebElement element = _webDriver.FindElement(SSWinLocators._applicationSearchBoxInput, true);
                Actions actions = new Actions(_webDriver);
                actions.MoveToElement(element).SendKeys(Keys.Enter).Perform(); 
            }
            _webDriver.FindElement(By.XPath($"//div[@style='outline-style:none;' and .//div[.='{testData.App}']]"), true).Click();
            _webDriver.FindElement(SSWinLocators._deleteBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._confirmDialogOKBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject OpenAppsTypes()
        {
            _webDriver.FindElement(LeftMainPanelLocators._SystemStructureBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._appsTypesBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject CreateAppType(SSWinCreateAppsTypesTestData testData)
        {
            _webDriver.FindElement(SSWinLocators._createBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._appNameInput, true).Click();
            _webDriver.FindElement(SSWinLocators._appNameInput, true).SendKeys(testData.Name);
            _webDriver.FindElement(SSWinLocators._appIdentifierInput, true).Click();
            _webDriver.FindElement(SSWinLocators._appIdentifierInput, true).SendKeys(testData.Name);

            if (testData.IsCorporate)
            {
                _webDriver.FindElement(SSWinLocators._isCorporativeChkBox, true).Click();
            }
            if (testData.IsWithModules)
            {
                _webDriver.FindElement(SSWinLocators._isWithModules, true).Click();
            }

            _webDriver.FindElement(SSWinLocators._saveAndCloseBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject OpenWSS()
        {
            _webDriver.FindElement(LeftMainPanelLocators._SystemStructureBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._WSSBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject CreateWSS(SSWinOrgsCreateWSSTestData testData)
        {
            _webDriver.FindElement(SSWinLocators._createBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._WSSAppInput, true).Click();
            _webDriver.FindElement(SSWinLocators._WSSAppInput, true).SendKeys(testData.App);
            string xpath = $"//td[contains(text(),'{testData.App}')]";
            _webDriver.FindElement(By.XPath(xpath), true).Click();
            _webDriver.FindElement(SSWinLocators._saveAndCloseBtn).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject OpenClientsSettings()
        {
            _webDriver.FindElement(LeftMainPanelLocators._SystemStructureBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._ClientsSettingsBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject CreateClientsSettings(SSWinCreateClientsAppSettingsTestData testData)
        {
            _webDriver.FindElement(SSWinLocators._createBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._сlientsSettingsAppInput, true).Click();
            _webDriver.FindElement(SSWinLocators._сlientsSettingsAppInput, true).SendKeys(testData.App);
            string xpath = $"//td[contains(text(),'{testData.App}')]";
            _webDriver.FindElement(By.XPath(xpath), true).Click();
            _webDriver.FindElement(SSWinLocators._сlientsSettingsTypeInput, true).Click();
            _webDriver.FindElement(SSWinLocators._сlientsSettingsTypeInput, true).SendKeys(testData.ClientsAppType);
            _webDriver.FindElement(SSWinLocators._saveBtn, true).Click();
            WaitUntil.WaitSomeInterval(1);
            _webDriver.FindElement(SSWinLocators._closeBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject OpenTerr()
        {
            _webDriver.FindElement(LeftMainPanelLocators._SystemStructureBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._TerrBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }

        internal SSWinPageObject CreateTerr(SSWinCreateTerrTestData testData)
        {
            _webDriver.FindElement(SSWinLocators._createBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._terrOrganizationInput, true).Click();
            _webDriver.FindElement(SSWinLocators._terrOrganizationInput, true).SendKeys(testData.Organization);
            string xpath = $"//td[contains(text(),'{testData.Organization}')]";
            _webDriver.FindElement(By.XPath(xpath), true).Click();
            _webDriver.FindElement(SSWinLocators._terrIdentifierInput, true).Click();
            _webDriver.FindElement(SSWinLocators._terrIdentifierInput, true).SendKeys(testData.Identifier);
            _webDriver.FindElement(SSWinLocators._terrNameInput, true).Click();
            _webDriver.FindElement(SSWinLocators._terrNameInput, true).SendKeys(testData.Name);
            if (testData.IsCentral)
            {
                _webDriver.FindElement(SSWinLocators._terrIsCentralChkBox, true).Click();
            }
            _webDriver.FindElement(SSWinLocators._terrPrefixInput, true).Click();
            _webDriver.FindElement(SSWinLocators._terrPrefixInput, true).SendKeys(testData.Prefix);
            _webDriver.FindElement(SSWinLocators._terrTimeZoneSettingsBtn, true).Click();

            if (testData.IsCentralTerrTimeZoneUsed)
            {
                _webDriver.FindElement(SSWinLocators._terrIsCentralTerrTimeZoneUsedChkBox, true).Click();
            }
            else
            {
                _webDriver.FindElement(SSWinLocators._terrTimeZoneInput, true).Click();
                _webDriver.FindElement(SSWinLocators._terrTimeZoneInput, true).SendKeys(testData.TimeZone);
                _webDriver.FindElement(SSWinLocators._terrHeadingListBox, true).Click();
                xpath = $"//option[@value='{testData.Heading}']";
                _webDriver.FindElement(By.XPath(xpath), true).Click();
            }

            _webDriver.FindElement(SSWinLocators._saveBtn, true).Click();
            WaitUntil.WaitSomeInterval(1);
            _webDriver.FindElement(SSWinLocators._closeBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }
    }
}