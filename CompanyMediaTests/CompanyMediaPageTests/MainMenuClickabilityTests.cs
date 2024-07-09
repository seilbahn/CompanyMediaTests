using CompanyMediaTests.PageObjects;
using CompanyMediaTests.Urls;
using CompanyMediaTests.Utility;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

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
        }

        [Test, Repeat(10)]
        public void ChooseCity()
        {
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
