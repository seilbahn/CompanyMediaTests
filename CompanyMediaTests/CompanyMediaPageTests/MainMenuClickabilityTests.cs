using CompanyMediaTests.PageObjects;
using CompanyMediaTests.Urls;
using CompanyMediaTests.Utility;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using CompanyMediaTests.Locators;
using CompanyMediaTests.TestData;

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
            logInPage.LogIn(LogInPageTestData.UserName, LogInPageTestData.Password);
            driver.WaitDocumentReadyState();
        }

        [Test, Repeat(10)]
        public void ClickOnSystemStructure()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenSystemStructureWindow();
            driver.WaitDocumentReadyState();
            try
            {
                IWebElement systemStructureBreadcrumbsBtn = driver
                    .FindElement(SystemStructureWindowLocators._systemStructureBreadcrumbsBtn, true);
                bool isElementPresent = systemStructureBreadcrumbsBtn.Displayed && systemStructureBreadcrumbsBtn.Enabled;
                Assert.That(isElementPresent, Is.EqualTo(true),
                    $"The button {SystemStructureWindowLocators._systemStructureBreadcrumbsBtn} was not found.");
            }
            catch
            {
                Assert.Fail($"The button {SystemStructureWindowLocators._systemStructureBreadcrumbsBtn} was not found.");
            }
        }

        [Test, Repeat(10)]
        public void ClickOnOrganization()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenOrganizationWindow();
            driver.WaitDocumentReadyState();
            try
            {
                IWebElement organizationBreadcrumbsBtn = driver
                    .FindElement(OrganizationWindowLocators._organizationBreadcrumbsBtn, true);
                bool isElementPresent = organizationBreadcrumbsBtn.Displayed && organizationBreadcrumbsBtn.Enabled;
                Assert.That(isElementPresent, Is.EqualTo(true),
                    $"The button {OrganizationWindowLocators._organizationBreadcrumbsBtn} was not found.");
            }
            catch
            {
                Assert.Fail($"The button {OrganizationWindowLocators._organizationBreadcrumbsBtn} was not found.");
            }
        }

        [Test, Repeat(10)]
        public void ClickOnOrganizationsDataBook()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenOrganizationsDataBookWindow();
            driver.WaitDocumentReadyState();
            try
            {
                IWebElement organizationDataBookBreadcrumbsBtn = driver
                    .FindElement(OrganizationsDataBookWindowLocators._organizationsDataBookBreadcrumbsBtn, true);
                bool isElementPresent = organizationDataBookBreadcrumbsBtn.Displayed && organizationDataBookBreadcrumbsBtn.Enabled;
                Assert.That(isElementPresent, Is.EqualTo(true),
                    $"The button {OrganizationsDataBookWindowLocators._organizationsDataBookBreadcrumbsBtn} was not found.");
            }
            catch
            {
                Assert.Fail($"The button {OrganizationsDataBookWindowLocators._organizationsDataBookBreadcrumbsBtn} was not found.");
            }
        }

        [Test, Repeat(10)]
        public void ClickOnPersonsDataBook()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenPersonsDataBookWindow();
            driver.WaitDocumentReadyState();
            try
            {
                IWebElement personsDataBookBreadcrumbsBtn = driver
                    .FindElement(PersonsDataBookWindowLocators._personsDataBookBreadcrumbsBtn, true);
                bool isElementPresent = personsDataBookBreadcrumbsBtn.Displayed && personsDataBookBreadcrumbsBtn.Enabled;
                Assert.That(isElementPresent, Is.EqualTo(true),
                    $"The button {PersonsDataBookWindowLocators._personsDataBookBreadcrumbsBtn} was not found.");
            }
            catch
            {
                Assert.Fail($"The button {PersonsDataBookWindowLocators._personsDataBookBreadcrumbsBtn} was not found.");
            }
        }

        [Test, Repeat(10)]
        public void ClickOnClassifiers()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenClassifiersWindow();
            driver.WaitDocumentReadyState();
            try
            {
                IWebElement classifiersBreadcrumbsBtn = driver
                    .FindElement(ClassifiersWindowLocators._classifiersBreadcrumbsBtn, true);
                bool isElementPresent = classifiersBreadcrumbsBtn.Displayed && classifiersBreadcrumbsBtn.Enabled;
                Assert.That(isElementPresent, Is.EqualTo(true),
                    $"The button {ClassifiersWindowLocators._classifiersBreadcrumbsBtn} was not found.");
            }
            catch
            {
                Assert.Fail($"The button {ClassifiersWindowLocators._classifiersBreadcrumbsBtn} was not found.");
            }
        }

        [Test, Repeat(10)]
        public void ClickOnAgents()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenAgentsWindow();
            driver.WaitDocumentReadyState();
            try
            {
                IWebElement agentsBreadcrumbsBtn = driver
                    .FindElement(AgentsWindowLocators._agentsBreadcrumbsBtn, true);
                bool isElementPresent = agentsBreadcrumbsBtn.Displayed && agentsBreadcrumbsBtn.Enabled;
                Assert.That(isElementPresent, Is.EqualTo(true),
                    $"The button {AgentsWindowLocators._agentsBreadcrumbsBtn} was not found.");
            }
            catch
            {
                Assert.Fail($"The button {AgentsWindowLocators._agentsBreadcrumbsBtn} was not found.");
            }
        }

        [Test, Repeat(10)]
        public void ClickOnReports()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenReportsWindow();
            driver.WaitDocumentReadyState();
            try
            {
                IWebElement createReportBtn = driver
                    .FindElement(ReportsWindowLocators._createReportBtn, true);
                bool isElementPresent = createReportBtn.Displayed && createReportBtn.Enabled;
                Assert.That(isElementPresent, Is.EqualTo(true),
                    $"The button {ReportsWindowLocators._createReportBtn} was not found.");
            }
            catch
            {
                Assert.Fail($"The button {ReportsWindowLocators._createReportBtn} was not found.");
            }
        }

        [Test, Repeat(10)]
        public void ClickOnToolPalette()
        {
            MainPagePageObject mainPage = new MainPagePageObject(driver);
            mainPage.OpenToolPaletteWindow();
            driver.WaitDocumentReadyState();
            try
            {
                IWebElement toolPaletteBreadcrumbsBtn = driver
                    .FindElement(ToolPaletteWindowLocators._toolPaletteBreadcrumbsBtn, true);
                bool isElementPresent = toolPaletteBreadcrumbsBtn.Displayed && toolPaletteBreadcrumbsBtn.Enabled;
                Assert.That(isElementPresent, Is.EqualTo(true),
                    $"The button {ToolPaletteWindowLocators._toolPaletteBreadcrumbsBtn} was not found.");
            }
            catch
            {
                Assert.Fail($"The button {ToolPaletteWindowLocators._toolPaletteBreadcrumbsBtn} was not found.");
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