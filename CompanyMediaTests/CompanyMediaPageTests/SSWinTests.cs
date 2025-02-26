﻿using CompanyMediaTests.Locators;
using CompanyMediaTests.PageObjects;
using CompanyMediaTests.TestData;
using CompanyMediaTests.Urls;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CompanyMediaTests.CompanyMediaPageTests
{
    /// <summary>
    /// Автотесты для окна Структура Системы -> Приложения.    /// 
    /// </summary>
    internal class SSWinTests
    {
        private IWebDriver webDriver;
        private Driver driver;
        private Reporter excelReport;
        private List<(string, int, string, string, string)> units;

        [OneTimeSetUp]
        public void Prepare()
        {
            units = new List<(string, int, string, string, string)>();
            excelReport = new Reporter(Path.Combine(Options.ExcelReportsDirectoryPath,
                TestContext.CurrentContext.Test.Name + " " + Helper.GenerateFileName(Reports.Excel)));
        }

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            chromeOptions.AddArgument("--lang=ru");
            webDriver = new ChromeDriver(chromeOptions);

            string iteration = $"Iteration {TestContext.CurrentContext.CurrentRepeatCount} ";
            string logFileName = Helper.GenerateFileName(Reports.Txt, iteration + TestContext.CurrentContext.Test.Name.ToString());
            string logDirectoryName = TestContext.CurrentContext.Test.ClassName!.ToString();
            string logMethodDirectoryName = TestContext.CurrentContext.Test.MethodName!.ToString();
            string pathToLogFile = Path.Combine(Options.LogsDirectoryPath, logDirectoryName, logMethodDirectoryName, logFileName);
            Notetaker logger = new Notetaker(pathToLogFile);

            driver = new Driver(webDriver, logger);
            driver.Notetaker.Logger.Information($"Start. Method name: {TestContext.CurrentContext.Test.FullName}");
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(CompanyMediaWebUrls.LogInPageUrl);
            driver.WaitDocumentReadyState();
            LogInPagePageObject logInPage = new LogInPagePageObject(driver);
            logInPage.LogIn(new LogInPageTestData(true).UserName, new LogInPageTestData(true).Password);
            driver.WaitDocumentReadyState();

            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenSystemStructureWindow();
            driver.WaitDocumentReadyState();
        }

        /// <summary>
        /// Создание одного элемента из блока «Приложения».
        /// Открывается окно создания, заполняются данные, нажимается кнопка «Сохранить и Закрыть».
        /// После создания проверяется, появился ли созданный элемент в таблице «Приложения».
        /// </summary>
        [Test, Repeat(10)]
        public void CreateApps()
        {
            SSWinPageObject systemStructure = new SSWinPageObject(driver);
            systemStructure.OpenApps();

            SSWinAppsTestData testData = new SSWinAppsTestData(new Random().Next(0, 4));
            testData.Name += Helper.RandomString(new Random(), 7);
            testData.PackageName += Helper.RandomString(new Random(), 7);
            testData.FileName += Helper.RandomString(new Random(), 7);
            systemStructure.CreateApp(testData);

            string xpath = $"//div[@style='outline-style:none;' and .//div[.='{testData.Name}']]";
            IWebElement item = driver.FindElement(By.XPath(xpath), true);
            Assert.That(driver.IsElementPresent(By.XPath(xpath)), Is.EqualTo(true), $"{item} was not found.");
        }

        /// <summary>
        /// Создание одного элемента из блока «Приложения организаций».
        /// Открывается окно создания, заполняются данные, нажимается кнопка «Сохранить и Закрыть».
        /// После создания проверяется, появился ли созданный элемент в таблице «Приложения организаций».
        /// После проверки созданное приложение удаляется.
        /// </summary>
        [Test, Repeat(10)]
        public void CreateDeleteOrgsApps()
        {
            SSWinPageObject systemStructure = new SSWinPageObject(driver);
            systemStructure.OpenOrgsApps();

            SSWinOrgsAppsTestData testData = new SSWinOrgsAppsTestData(new Random().Next(0, 4));
            systemStructure.CreateOrgsApps(testData);

            driver.FindElement(SSWinLocators._applicationSearchBoxInput, true).SendKeys(testData.App);
            IWebElement element = driver.FindElement(SSWinLocators._applicationSearchBoxInput, true);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).SendKeys(Keys.Enter).Perform();
            string xpath = $"//div[@style='outline-style:none;' and .//div[.='{testData.App}']]";
            IWebElement item = driver.FindElement(By.XPath(xpath), true);
            Assert.That(driver.IsElementPresent(By.XPath(xpath)), Is.EqualTo(true), $"{item} was not found.");

            systemStructure.OpenOrgsApps();
            driver.FindElement(SSWinLocators._applicationSearchBoxInput, true).Click();
            driver.FindElement(SSWinLocators._applicationSearchBoxInput, true).Clear();           
            systemStructure.DeleteOrgsApp(testData);
        }

        /// <summary>
        /// Создание одного элемента из блока «Типы приложений».
        /// Открывается окно создания, заполняются данные, нажимается кнопка «Сохранить и Закрыть».
        /// После создания проверяется, появился ли созданный элемент в таблице «Типы приложений».
        /// </summary>
        [Test, Repeat(10)]
        public void CreateAppType()
        {
            SSWinPageObject systemStructure = new SSWinPageObject(driver);
            systemStructure.OpenAppsTypes();

            SSWinCreateAppsTypesTestData testData = new SSWinCreateAppsTypesTestData(new Random().Next(0, 4));
            testData.Name += Helper.RandomString(new Random(), 7);
            testData.Identifier += Helper.RandomString(new Random(), 7);
            systemStructure.CreateAppType(testData);

            string xpath = $"(//div[@style='outline-style:none;' and .//div[.='{testData.Name}']])[1]";
            IWebElement item = driver.FindElement(By.XPath(xpath), true);
            Assert.That(driver.IsElementPresent(By.XPath(xpath)), Is.EqualTo(true), $"{item} was not found.");
        }

        /// <summary>
        /// Создание одного элемента из блока «Настройки Web-поиска».
        /// Открывается окно создания, заполняются данные, нажимается кнопка «Сохранить и Закрыть».
        /// После создания проверяется, появился ли созданный элемент в таблице «Настройки Web-поиска».
        /// </summary>
        [Test, Repeat(10)]
        public void CreateWSS()
        {
            SSWinPageObject systemStructure = new SSWinPageObject(driver);
            systemStructure.OpenWSS();

            SSWinOrgsCreateWSSTestData testData = new SSWinOrgsCreateWSSTestData(new Random().Next(0, 3));
            systemStructure.CreateWSS(testData);

            string xpath = $"(//div[@style='outline-style:none;' and .//div[.='{testData.App}']])[1]";
            IWebElement item = driver.FindElement(By.XPath(xpath), true);
            Assert.That(driver.IsElementPresent(By.XPath(xpath)), Is.EqualTo(true), $"{item} was not found.");
        }

        /// <summary>
        /// Создание одного элемента из блока «Настройки клиентских приложений».
        /// Открывается окно создания, заполняются данные, нажимается кнопка «Сохранить», а затем «Закрыть».
        /// После создания проверяется, появился ли созданный элемент в таблице «Настройки клиентских приложений».
        /// </summary>
        [Test, Repeat(10)]
        public void CreateClientsSettings()
        {
            SSWinPageObject systemStructure = new SSWinPageObject(driver);
            systemStructure.OpenClientsSettings();

            SSWinCreateClientsAppSettingsTestData testData = new SSWinCreateClientsAppSettingsTestData(new Random().Next(0, 3));
            testData.ClientsAppType += Helper.RandomString(new Random(), 7);
            systemStructure.CreateClientsSettings(testData);

            string xpath = $"(//div[@style='outline-style:none;' and .//div[.='{testData.ClientsAppType}']])[1]";
            IWebElement item = driver.FindElement(By.XPath(xpath), true);
            Assert.That(driver.IsElementPresent(By.XPath(xpath)), Is.EqualTo(true), $"{item} was not found.");
        }

        /// <summary>
        /// Создание одного элемента из блока «Территории».
        /// Открывается окно создания, заполняются данные, нажимается кнопка «Сохранить», а затем «Закрыть».
        /// После создания проверяется, появился ли созданный элемент в таблице «Настройки клиентских приложений».
        /// </summary>
        [Test, Repeat(10)]
        public void CreateTerr()
        {
            SSWinPageObject systemStructure = new SSWinPageObject(driver);
            systemStructure.OpenTerr();

            SSWinCreateTerrTestData testData = new SSWinCreateTerrTestData(new Random().Next(0, 11));

            testData.Identifier += Helper.RandomString(new Random(), 7);
            testData.Name += Helper.RandomString(new Random(), 7);
            systemStructure.CreateTerr(testData);

            string xpath = $"(//div[@style='outline-style:none;' and .//div[.='{testData.Identifier}']])[1]";
            IWebElement item = driver.FindElement(By.XPath(xpath), true);
            Assert.That(driver.IsElementPresent(By.XPath(xpath)), Is.EqualTo(true), $"{item} was not found.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Notetaker.Logger.Information($"Final. Method name: {TestContext.CurrentContext.Test.FullName}");
            webDriver.Dispose();
            driver.Dispose();

            units.Add((TestContext.CurrentContext.Test.Name,
                      TestContext.CurrentContext.CurrentRepeatCount,
                      TestContext.CurrentContext.Test.Name,
                      TestContext.CurrentContext.Result.Outcome.ToString()!,
                      driver.Notetaker.Path));
        }

        [OneTimeTearDown]
        public void Finalizing()
        {
            excelReport.Create(units);
        }
    }
}