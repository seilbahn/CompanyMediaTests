using CompanyMediaTests.PageObjects;
using CompanyMediaTests.Urls;
using CompanyMediaTests.Utility;
using CompanyMediaTests.TestData;
using CompanyMediaTests.Locators;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace CompanyMediaTests.CompanyMediaPageTests
{
    internal class LogInPageTests
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
        }

        [Test, Repeat(10)]
        public void LogIn()
        {
            driver.Navigate().GoToUrl(CompanyMediaWebUrls.LogInPageUrl);
            driver.WaitDocumentReadyState();
            LogInPagePageObject logInPage = new LogInPagePageObject(driver);
            logInPage.LogIn(LogInPageTestData.UserName, LogInPageTestData.Password);
            driver.WaitDocumentReadyState();
            WaitUntil.WaitElement(driver, LeftMainPanelLocators._userBtn);
            IWebElement userButton = driver.FindElement(LeftMainPanelLocators._userBtn, true);
            userButton.Click();
            IWebElement login = driver.FindElement(LeftMainPanelLocators._loginInformationLabel, true);
            IWebElement name = driver.FindElement(LeftMainPanelLocators._nameInformationLabel, true);
            IWebElement surname = driver.FindElement(LeftMainPanelLocators._surnameInformationLabel, true);
            IWebElement email = driver.FindElement(LeftMainPanelLocators._emailInformationLabel, true);
            string actualLogin = login.Text.Substring(7);
            string actualName = name.Text.Substring(5);
            string actualSurname = surname.Text.Substring(8);
            string actualEmail = email.Text.Substring(7);
            Assert.That(actualLogin, Is.EqualTo(MainPageTestData.Login),
                        "The expected and the actual logins are not equal.");            
            Assert.That(actualName, Is.EqualTo(MainPageTestData.Name),
                        "The expected and the actual names are not equal.");            
            Assert.That(actualSurname, Is.EqualTo(MainPageTestData.Surname),
                        "The expected and the actual surnames are not equal.");            
            Assert.That(actualEmail, Is.EqualTo(MainPageTestData.Email),
                        "The expected and the actual emails are not equal.");
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
