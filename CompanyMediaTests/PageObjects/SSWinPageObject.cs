using CompanyMediaTests.Locators;
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
            //IWebElement element = _webDriver.FindElement(SSWinLocators._applicationSearchBoxInput, true);
            //Actions actions = new Actions(_webDriver);
            //actions.MoveToElement(element).SendKeys(Keys.Enter).Perform(); 

            _webDriver.FindElement(SSWinLocators._createBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._organizationDropDownList, true).Click();
            _webDriver.FindElement(SSWinLocators._organizationDropDownList, true).Click();
            string xpath = $"//td[text()='{testData.Organization}']";
            _webDriver.FindElement(By.XPath(xpath), true).Click();
            _webDriver.FindElement(SSWinLocators._applicationInput, true).Click();
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
                WaitUntil.WaitSomeInterval(3);

                IWebElement element = _webDriver.FindElement(SSWinLocators._applicationSearchBoxInput, true);
                Actions actions = new Actions(_webDriver);
                actions.MoveToElement(element).SendKeys(Keys.Enter).Perform(); 

                //_webDriver.FindElement(SSWinLocators._applicationSearchBoxInput, true).SendKeys(Keys.Enter);
            }
            _webDriver.FindElement(By.XPath($"//div[@style='outline-style:none;' and .//div[.='{testData.App}']]"), true).Click();
            _webDriver.FindElement(SSWinLocators._deleteBtn, true).Click();
            _webDriver.FindElement(SSWinLocators._confirmDialogOKBtn, true).Click();

            return new SSWinPageObject(_webDriver);
        }
    }
}