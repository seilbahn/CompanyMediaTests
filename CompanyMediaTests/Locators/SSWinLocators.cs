﻿using OpenQA.Selenium;

namespace CompanyMediaTests.Locators
{
    internal class SSWinLocators
    {
        internal static readonly By _systemStructureBreadcrumbsBtn = By.XPath("//a[@href='#link=SS']");

        internal static readonly By _errorDialogWindow = By.XPath("//div[@class='errorDialogWindow']");
        internal static readonly By _errorDialogOKBtn = By.XPath("//button[@type='button' and @class='darkButton' and text()='ОК']");
        internal static readonly By _confirmDialogOKBtn = By.XPath("//button[@type='button' and @class='darkButton' and text()='ОК']");

        internal static readonly By _appsBtn = By.XPath("//div[@class='treeItemTitle' and text()='Приложения']");
        internal static readonly By _orgsAppsBtn = By.XPath("//div[@class='treeItemTitle' and text()='Приложения организаций']");
        internal static readonly By _appsTypesBtn = By.XPath("//div[@class='treeItemTitle' and text()='Типы приложений']");
        internal static readonly By _WSSBtn = By.XPath("//div[@class='treeItemTitle' and text()='Настройки Web-поиска']");
        internal static readonly By _ClientsSettingsBtn = By.XPath("//div[@class='treeItemTitle' and @title='Настройки клиентских приложений']");
        internal static readonly By _TerrBtn = By.XPath("//div[@class='treeItemTitle' and text()='Территории']");

        internal static readonly By _renewBtn = By.XPath("//a[@class='action-bar-button' and text()='Обновить']");
        internal static readonly By _createBtn = By.XPath("//a[@class='action-bar-button' and text()='Создать']");
        internal static readonly By _editBtn = By.XPath("//a[@class='action-bar-button' and text()='Редактировать']");
        internal static readonly By _deleteBtn = By.XPath("//a[@class='action-bar-button' and text()='Удалить']");
        internal static readonly By _saveAndCloseBtn = By.XPath("//a[@class='action-bar-button' and text()='Сохранить и Закрыть']");
        internal static readonly By _saveBtn = By.XPath("//a[@class='action-bar-button' and text()='Сохранить']");
        internal static readonly By _closeBtn = By.XPath("//a[@class='action-bar-button' and text()='Закрыть']");

        // Локаторы для подкатегории «Приложения»
        // Only as a example for the first line that named as 'Test Doc Projects':
        internal static readonly By _tableLine = By.XPath("//div[@style='outline-style:none;' and .//div[.='Test Doc Projects']]");

        internal static readonly By _typeDropDownList = By.XPath("(//td[@class='suggest-container-arrow-btn'])[1]");

        // Only as a example for the first item in drop list that named as 'DocProjects':
        internal static readonly By _typeDropDownListItem = By.XPath("//td[@class='item' and @role='menuitem' and text()='DocProjects']");

        internal static readonly By _nameInput = By.XPath("(//input[@type='text' and @class='gwt-TextBox'])[1]");
        internal static readonly By _nonSysModuleChkBox = By.XPath("(//input[@type='checkbox'])[1]");

        internal static readonly By _basicModuleTypeDropDownList = By.XPath("(//td[@class='suggest-container-arrow-btn'])[2]");

        // Only as a example for the first item in drop list that named as 'DocProjects':
        internal static readonly By _basicModuleTypeDropDownListItem = By.XPath("//td[@class='item' and @role='menuitem' and text()='DocProjects']");

        internal static readonly By _packageInput = By.XPath("(//input[@type='text' and @class='gwt-TextBox'])[2]");
        internal static readonly By _protocolAppDropDownList = By.XPath("(//td[@class='suggest-container-arrow-btn'])[3]");

        // Only as a example for the first item in drop list that named as 'CC':
        internal static readonly By _protocolAppDropDownListItem = By.XPath("//td[@class='item' and @role='menuitem' and text()='CC']");

        internal static readonly By _projectsAppDropDownList = By.XPath("(//td[@class='suggest-container-arrow-btn'])[4]");

        // Only as a example for the first item in drop list that named as 'CC':
        internal static readonly By _projectsAppDropDownListItem = By.XPath("//td[@class='item' and @role='menuitem' and text()='CC']");

        internal static readonly By _fileNameInput = By.XPath("(//input[@type='text' and @class='gwt-TextBox'])[4]");
        internal static readonly By _namedAppChkBox = By.XPath("(//input[@type='checkbox'])[2]");
        internal static readonly By _storageDropDownList = By.XPath("(//td[@class='suggest-container-arrow-btn'])[5]");

        // Only as a example for the first item in drop list that named as 'AF5':
        internal static readonly By _storageDropDownListItem = By.XPath("//td[@class='item' and @role='menuitem' and text()='AF5']");

        // Локаторы для подкатегории «Приложения организаций»
        internal static readonly By _organizationDropDownList = _typeDropDownList;
        internal static readonly By _organizationInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-SuggestBox')])[1]");
        internal static readonly By _applicationDropDownList = _basicModuleTypeDropDownList;
        internal static readonly By _applicationInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-SuggestBox')])[2]");
        internal static readonly By _applicationSearchBoxInput = By.XPath("(//input[@type='text' and @class='search-box'])[1]");
        internal static readonly By _organizationSearchBoxInput = By.XPath("(//input[@type='text' and @class='search-box'])[2]");

        // Локаторы для подкатегории «Типы приложений»
        internal static readonly By _appNameInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-TextBox')])[1]");
        internal static readonly By _appIdentifierInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-TextBox')])[2]");
        internal static readonly By _isCorporativeChkBox = By.XPath("(//input[@type='checkbox'])[1]");
        internal static readonly By _isWithModules = By.XPath("(//input[@type='checkbox'])[2]");

        // Локаторы для подкатегории «Настройки Web-поиска»
        internal static readonly By _WSSAppInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-SuggestBox')])[1]");

        // Локаторы для подкатегории «Настройки клиентского приложения»
        internal static readonly By _сlientsSettingsAppInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-SuggestBox')])[1]");
        internal static readonly By _сlientsSettingsTypeInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-TextBox')])[1]");

        // Локаторы для подкатегории «Настройки клиентского приложения»
        internal static readonly By _terrOrganizationInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-SuggestBox')])[1]");
        internal static readonly By _terrIdentifierInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-TextBox')])[1]");
        internal static readonly By _terrNameInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-TextBox')])[2]");
        internal static readonly By _terrIsCentralChkBox = By.XPath("(//input[@type='checkbox'])[1]");
        internal static readonly By _terrPrefixInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-TextBox')])[3]");
        internal static readonly By _terrGroupAccessCounterInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-TextBox')])[4]");
        internal static readonly By _terrTimeZoneSettingsBtn = By.XPath("//a[text()='Настройки часового пояса']");
        internal static readonly By _terrIsCentralTerrTimeZoneUsedChkBox = By.XPath("(//input[@type='checkbox'])[2]");
        internal static readonly By _terrTimeZoneInput = By.XPath("(//input[@type='text' and contains(@class, 'gwt-TextBox')])[5]");
        internal static readonly By _terrHeadingListBox = By.XPath("(//select[@class='gwt-ListBox'])[1]");
        internal static readonly By _terrHeadingOptionEast = By.XPath("//option[@value='к востоку от Гринвича']");
        internal static readonly By _terrHeadingOptionWest = By.XPath("//option[@value='к западу от Гринвича']");
    }
}