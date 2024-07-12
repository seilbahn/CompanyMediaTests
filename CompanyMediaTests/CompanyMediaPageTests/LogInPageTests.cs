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
    /// Автотесты для веб-страницы http://IPv4:8080/cm5div6/Login.html. 
    /// Только автотесты для авторизации.
    /// </summary>
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

        /// <summary>
        /// Авторизация с действительным именем пользователя и действительным паролем.
        /// После авторизации открывается страница http://IPv4:8080/cm5div6/BusinessUniverse.html.
        /// </summary>
        [Test, Repeat(10)]
        public void ValidUserLogIn()
        {
            driver.Navigate().GoToUrl(CompanyMediaWebUrls.LogInPageUrl);
            driver.WaitDocumentReadyState();

            LogInPagePageObject logInPage = new LogInPagePageObject(driver);
            logInPage.LogIn(new LogInPageTestData(true).UserName, new LogInPageTestData(true).Password);
            driver.WaitDocumentReadyState();

            IWebElement userButton = driver.FindElement(LeftMainPanelLocators._userBtn, true);
            userButton.Click();

            string actualLogin = driver.FindElement(LeftMainPanelLocators._loginInformationLabel, true).Text[7..];
            string actualName = driver.FindElement(LeftMainPanelLocators._nameInformationLabel, true).Text[5..];
            string actualSurname = driver.FindElement(LeftMainPanelLocators._surnameInformationLabel, true).Text[8..];
            string actualEmail = driver.FindElement(LeftMainPanelLocators._emailInformationLabel, true).Text[7..];

            Assert.Multiple(() =>
            {
                Assert.That(actualLogin, Is.EqualTo(MainPageTestData.Login),
                             "The expected and the actual logins are not equal.");
                Assert.That(actualName, Is.EqualTo(MainPageTestData.Name),
                            "The expected and the actual names are not equal.");
                Assert.That(actualSurname, Is.EqualTo(MainPageTestData.Surname),
                            "The expected and the actual surnames are not equal.");
                Assert.That(actualEmail, Is.EqualTo(MainPageTestData.Email),
                            "The expected and the actual emails are not equal.");
            });
        }

        /// <summary>
        /// Попытка авторизации с недействительным именем пользователя и недействительным паролем.
        /// Выходит ошибка авторизации.
        /// </summary>
        [Test, Repeat(10)]
        public void InvalidUserLogIn()
        {
            driver.Navigate().GoToUrl(CompanyMediaWebUrls.LogInPageUrl);
            driver.WaitDocumentReadyState();

            LogInPagePageObject logInPage = new LogInPagePageObject(driver);
            logInPage.LogIn(new LogInPageTestData(false).UserName, new LogInPageTestData(false).Password);
            driver.WaitDocumentReadyState();

            Assert.That(driver.IsElementPresent(LogInPageLocators._authErrorMsgLabel),
                "The authorization error message was not found.");
        }

        /// <summary>
        /// Попытка авторизации без ввода имени пользователя и без ввода пароля.
        /// Выходит ошибка авторизации.
        /// </summary>
        [Test, Repeat(10)]
        public void EmptyDataLogIn()
        {
            driver.Navigate().GoToUrl(CompanyMediaWebUrls.LogInPageUrl);
            driver.WaitDocumentReadyState();

            LogInPagePageObject logInPage = new LogInPagePageObject(driver);
            logInPage.LogIn(string.Empty, string.Empty);
            driver.WaitDocumentReadyState();

            Assert.That(driver.IsElementPresent(LogInPageLocators._authErrorMsgLabel),
                "The authorization error message was not found.");
        }

        /// <summary>
        /// Попытка авторизации с действительным именем пользователя и недействительным паролем.
        /// Выходит ошибка авторизации.
        /// </summary>
        [Test, Repeat(10)]
        public void TrueLoginFalsePasswordLogIn()
        {
            driver.Navigate().GoToUrl(CompanyMediaWebUrls.LogInPageUrl);
            driver.WaitDocumentReadyState();

            LogInPagePageObject logInPage = new LogInPagePageObject(driver);
            logInPage.LogIn(new LogInPageTestData(true).UserName, new LogInPageTestData(false).Password);
            driver.WaitDocumentReadyState();

            Assert.That(driver.IsElementPresent(LogInPageLocators._authErrorMsgLabel),
                "The authorization error message was not found.");
        }

        /// <summary>
        /// Попытка авторизации с недействительным именем пользователя и действительным паролем.
        /// Выходит ошибка авторизации.
        /// </summary>
        [Test, Repeat(10)]
        public void FalseLoginTruePasswordLogIn()
        {
            driver.Navigate().GoToUrl(CompanyMediaWebUrls.LogInPageUrl);
            driver.WaitDocumentReadyState();

            LogInPagePageObject logInPage = new LogInPagePageObject(driver);
            logInPage.LogIn(new LogInPageTestData(false).UserName, new LogInPageTestData(true).Password);
            driver.WaitDocumentReadyState();

            Assert.That(driver.IsElementPresent(LogInPageLocators._authErrorMsgLabel),
                "The authorization error message was not found.");
        }

        /// <summary>
        /// Попытка авторизации без ввода имени пользователя и пароля, только нажимая клавишу «Войти».
        /// Выходит ошибка авторизации.
        /// </summary>
        [Test, Repeat(10)]
        public void SubmitBtnClicking()
        {
            driver.Navigate().GoToUrl(CompanyMediaWebUrls.LogInPageUrl);
            driver.WaitDocumentReadyState();

            for (int i = 0; i < 100; i++)
            {
                driver.FindElement(LogInPageLocators._logInButton, true).Click();
                driver.WaitDocumentReadyState();
                bool isPresent = driver.IsElementPresent(LogInPageLocators._authErrorMsgLabel);
                if (!isPresent)
                {
                    Assert.Fail("The authorization error message was not found.");
                    break;
                }
            }

            Assert.That(driver.IsElementPresent(LogInPageLocators._authErrorMsgLabel),
                "The authorization error message was not found.");
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