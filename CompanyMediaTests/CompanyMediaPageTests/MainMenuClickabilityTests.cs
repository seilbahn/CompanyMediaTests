using CompanyMediaTests.Locators;
using CompanyMediaTests.PageObjects;
using CompanyMediaTests.TestData;
using CompanyMediaTests.Urls;
using CompanyMediaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CompanyMediaTests.CompanyMediaPageTests
{
    public class MenuElementsClickabilityTests
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
            Beaver logger = new Beaver(pathToLogFile);

            driver = new Driver(webDriver, logger);
            driver.Log.Logger.Information($"Start. Method name: {TestContext.CurrentContext.Test.FullName}");
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(CompanyMediaWebUrls.LogInPageUrl);
            driver.WaitDocumentReadyState();
            LogInPagePageObject logInPage = new LogInPagePageObject(driver);
            logInPage.LogIn(new LogInPageTestData(true).UserName, new LogInPageTestData(true).Password);
            driver.WaitDocumentReadyState();
        }

        [Test, Repeat(10)]
        public void ClickOnSystemStructure()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenSystemStructureWindow();
            driver.WaitDocumentReadyState();
            By element = SystemStructureWindowLocators._systemStructureBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        [Test, Repeat(10)]
        public void ClickOnOrganization()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenOrganizationWindow();
            driver.WaitDocumentReadyState();
            By element = OrganizationWindowLocators._organizationBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        [Test, Repeat(10)]
        public void ClickOnOrganizationsDataBook()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenOrganizationsDataBookWindow();
            driver.WaitDocumentReadyState();
            By element = OrganizationsDataBookWindowLocators._organizationsDataBookBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        [Test, Repeat(10)]
        public void ClickOnPersonsDataBook()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenPersonsDataBookWindow();
            driver.WaitDocumentReadyState();
            By element = PersonsDataBookWindowLocators._personsDataBookBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        [Test, Repeat(10)]
        public void ClickOnClassifiers()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenClassifiersWindow();
            driver.WaitDocumentReadyState();
            By element = ClassifiersWindowLocators._classifiersBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        [Test, Repeat(10)]
        public void ClickOnAgents()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenAgentsWindow();
            driver.WaitDocumentReadyState();
            By element = AgentsWindowLocators._agentsBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        [Test, Repeat(10)]
        public void ClickOnReports()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenReportsWindow();
            driver.WaitDocumentReadyState();
            By element = ReportsWindowLocators._createReportBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        [Test, Repeat(10)]
        public void ClickOnToolPalette()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenToolPaletteWindow();
            driver.WaitDocumentReadyState();
            By element = ToolPaletteWindowLocators._toolPaletteBreadcrumbsBtn;
            Assert.That(driver.IsElementPresent(element), Is.EqualTo(true), $"{element} was not found.");
        }

        [Test, Repeat(10)]
        public void ClickOnLeftMainPanelElements()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            List<Action> couples = [ClickOnSystemStructure, ClickOnOrganization, ClickOnOrganizationsDataBook, ClickOnPersonsDataBook,
                                    ClickOnClassifiers,  ClickOnAgents, ClickOnReports, ClickOnToolPalette];
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                couples[i % couples.Count]();
            }

            for (int i = 0; i < 10; i++)
            {
                couples[random.Next(0, couples.Count)]();
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Log.Logger.Information($"Final. Method name: {TestContext.CurrentContext.Test.FullName}");
            webDriver.Dispose();
            driver.Dispose();

            units.Add((TestContext.CurrentContext.Test.Name,
                      TestContext.CurrentContext.CurrentRepeatCount,
                      TestContext.CurrentContext.Test.Name,
                      TestContext.CurrentContext.Result.Outcome.ToString()!,
                      driver.Log.Path));
        }

        [OneTimeTearDown]
        public void Finalizing()
        {
            excelReport.Create(units);
        }
    }
}