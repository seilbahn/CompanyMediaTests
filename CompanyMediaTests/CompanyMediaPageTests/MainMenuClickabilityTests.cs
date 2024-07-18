using CompanyMediaTests.Locators;
using CompanyMediaTests.PageObjects;
using CompanyMediaTests.TestData;
using CompanyMediaTests.Urls;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CompanyMediaTests.CompanyMediaPageTests
{
    /// <summary>
    /// Автотесты для веб-страницы http://IPv4:8080/cm5div6/BusinessUniverse.html. 
    /// Автотесты на кликабельность элементов на левой панели.
    /// </summary>
    internal class MenuElementsClickabilityTests
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
        }

        /// <summary>
        /// Нажатие на клавишу «Структура Системы» на левой панели элементов.
        /// Открывается окно с данными первой (под)категории. В начале навигационной цепочки находится «Структура Системы».
        /// </summary>
        [Test, Repeat(10)]
        public void ClickOnSystemStructure()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenSystemStructureWindow();
            driver.WaitDocumentReadyState();
            By element = SSWinLocators._systemStructureBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        /// <summary>
        /// Нажатие на клавишу «Организация» на левой панели элементов.
        /// Открывается окно с данными первой (под)категории. В начале навигационной цепочки находится «Организация».
        /// </summary>
        [Test, Repeat(10)]
        public void ClickOnOrganization()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenOrganizationWindow();
            driver.WaitDocumentReadyState();
            By element = OrganizationWindowLocators._organizationBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        /// <summary>
        /// Нажатие на клавишу «Справочник организаций» на левой панели элементов.
        /// Открывается окно с данными первой (под)категории. В начале навигационной цепочки находится «Справочник организаций».
        /// </summary>
        [Test, Repeat(10)]
        public void ClickOnOrganizationsDataBook()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenOrganizationsDataBookWindow();
            driver.WaitDocumentReadyState();
            By element = OrganizationsDataBookWindowLocators._organizationsDataBookBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        /// <summary>
        /// Нажатие на клавишу «Справочник персон» на левой панели элементов.
        /// Открывается окно с данными первой (под)категории. В начале навигационной цепочки находится «Справочник персон».
        /// </summary>
        [Test, Repeat(10)]
        public void ClickOnPersonsDataBook()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenPersonsDataBookWindow();
            driver.WaitDocumentReadyState();
            By element = PersonsDataBookWindowLocators._personsDataBookBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        /// <summary>
        /// Нажатие на клавишу «Классификаторы» на левой панели элементов.
        /// Открывается окно с данными первой (под)категории. В начале навигационной цепочки находится «Классификаторы».
        /// </summary>
        [Test, Repeat(10)]
        public void ClickOnClassifiers()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenClassifiersWindow();
            driver.WaitDocumentReadyState();
            By element = ClassifiersWindowLocators._classifiersBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        /// <summary>
        /// Нажатие на клавишу «Агенты» на левой панели элементов.
        /// Открывается окно с данными первой (под)категории. В начале навигационной цепочки находится «Агенты».
        /// </summary>
        [Test, Repeat(10)]
        public void ClickOnAgents()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenAgentsWindow();
            driver.WaitDocumentReadyState();
            By element = AgentsWindowLocators._agentsBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        /// <summary>
        /// Нажатие на клавишу «Отчеты» на левой панели элементов.
        /// Открывается окно с кнопкой «Создать Отчет».
        /// </summary>
        [Test, Repeat(10)]
        public void ClickOnReports()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenReportsWindow();
            driver.WaitDocumentReadyState();
            By element = ReportsWindowLocators._createReportBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        /// <summary>
        /// Нажатие на клавишу «Палитра инструментов» на левой панели элементов.
        /// Открывается окно с данными первой (под)категории. В начале навигационной цепочки находится «Палитра инструментов».
        /// </summary>
        [Test, Repeat(10)]
        public void ClickOnToolPalette()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenToolPaletteWindow();
            driver.WaitDocumentReadyState();
            By element = ToolPaletteWindowLocators._toolPaletteBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        /// <summary>
        /// Поочередное нажатие на все 8 элементов («Структура Системы», «Организация», «Справочник организаций», 
        /// «Справочник персон», «Классификаторы», «Агенты», «Отчеты», «Палитра инструментов») левой панели элементов.
        /// При нажатии на элемент открывается окно с данными первой (под)категории, для элемента «Отчеты» открывается окно 
        /// с кнопкой «Создать Отчет». (Повтор всех вышенаписанных тестов).
        /// !!! Ошибки
        /// </summary>
        [Test, Repeat(3)]
        public void ClickOnLeftMainPanelElements()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            List<Action> couples = [ClickOnSystemStructure, ClickOnOrganization, ClickOnOrganizationsDataBook, ClickOnPersonsDataBook,
                                    ClickOnClassifiers,  ClickOnAgents, ClickOnReports, ClickOnToolPalette];
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                couples[i % couples.Count]();
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    couples[random.Next(0, couples.Count)]();
            //}
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