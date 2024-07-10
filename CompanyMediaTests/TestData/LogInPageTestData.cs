using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal static class LogInPageTestData
    {
        internal static string UserName { get; }
        internal static string Password { get; }

        static LogInPageTestData()
        {
            Excel excel = new Excel(MainTestData.ExcelFile);
            UserName = excel.ReadCell("LogInData", 2, 2) ?? "admin";
            Password = excel.ReadCell("LogInData", 2, 3) ?? "admin";
        }
    }
}