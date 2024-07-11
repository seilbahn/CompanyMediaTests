using CompanyMediaTests.Locators;
using CompanyMediaTests.TestData;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;

namespace CompanyMediaTests.PageObjects
{
    internal class SystemStructureWindowPageObject
    {
        private IWebDriver _webDriver;

        internal SystemStructureWindowPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        internal SystemStructureWindowPageObject OpenApps()
        {
            _webDriver.FindElement(LeftMainPanelLocators._SystemStructureBtn, true).Click();
            _webDriver.FindElement(LeftMainPanelLocators._PinBtn, true).Click();

            IWebElement element = _webDriver.FindElement(LeftMainPanelLocators._PinBtn);
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].click();", element);
            //_webDriver.FindElement(SystemStructureWindowLocators._appsBtn, true).Click();

            return new SystemStructureWindowPageObject(_webDriver);
        }

        internal SystemStructureWindowPageObject CreateApp(SystemStructureWindowTestData testData)
        {
            _webDriver.FindElement(SystemStructureWindowLocators._createBtn, true).Click();
            _webDriver.FindElement(SystemStructureWindowLocators._typeDropDownList, true).Click();
            _webDriver.FindElement(SystemStructureWindowLocators._typeDropDownList, true).Click();

            string xpath = $"//td[text()='{testData.Type}']";
            _webDriver.FindElement(By.XPath(xpath)).Click();

            _webDriver.FindElement(SystemStructureWindowLocators._nameInput, true).Click();
            _webDriver.FindElement(SystemStructureWindowLocators._nameInput, true).SendKeys(testData.Name);
            
            if (_webDriver.FindElement(SystemStructureWindowLocators._nonSysModuleChkBox, true).Selected)
            {
                _webDriver.FindElement(SystemStructureWindowLocators._nonSysModuleChkBox, true).Click();
            }           

            _webDriver.FindElement(SystemStructureWindowLocators._basicModuleTypeDropDownList, true).Click();
            xpath = $"//td[text()='{testData.BasicModuleType}']";
            _webDriver.FindElement(By.XPath(xpath), true).Click();
                    
            _webDriver.FindElement(SystemStructureWindowLocators._packageInput, true).Click();
            _webDriver.FindElement(SystemStructureWindowLocators._packageInput, true).Clear();
            _webDriver.FindElement(SystemStructureWindowLocators._packageInput, true).SendKeys(testData.PackageName);

            _webDriver.FindElement(SystemStructureWindowLocators._protocolAppDropDownList, true).Click();
            xpath = $"//td[text()='{testData.ProtocolApplication}']";
            _webDriver.FindElement(By.XPath(xpath), true).Click();

            _webDriver.FindElement(SystemStructureWindowLocators._projectsAppDropDownList, true).Click();
            xpath = $"//td[text()='{testData.ProjectsApplication}']";
            _webDriver.FindElement(By.XPath(xpath), true).Click();

            _webDriver.FindElement(SystemStructureWindowLocators._fileNameInput).Click();
            _webDriver.FindElement(SystemStructureWindowLocators._fileNameInput).Clear();
            _webDriver.FindElement(SystemStructureWindowLocators._fileNameInput).SendKeys(testData.FileName);

            if (_webDriver.FindElement(SystemStructureWindowLocators._namedAppChkBox, true).Selected)
            {
                _webDriver.FindElement(SystemStructureWindowLocators._namedAppChkBox, true).Click();
            }

            _webDriver.FindElement(SystemStructureWindowLocators._storageDropDownList, true).Click();
            xpath = $"//td[text()='{testData.Storage}']";
            _webDriver.FindElement(By.XPath(xpath), true).Click();

            _webDriver.FindElement(SystemStructureWindowLocators._saveAndCloseBtn).Click();

            return new SystemStructureWindowPageObject(_webDriver);
        }
    }
}