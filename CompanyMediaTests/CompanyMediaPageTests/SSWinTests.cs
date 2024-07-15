using CompanyMediaTests.Locators;
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
            Beaver logger = new Beaver(pathToLogFile);

            driver = new Driver(webDriver, logger);
            driver.Log.Logger.Information($"Start. Method name: {TestContext.CurrentContext.Test.FullName}");
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
        [Test, Repeat(100)]
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