using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal static class LogInTestData
    {
        public static string UserName { get; }
        public static string Password { get; }

        static LogInTestData()
        {
            Excel excel = new Excel(MainTestData.ExcelFile);
            UserName = excel.ReadCell("LogInData", 2, 2) ?? "admin";
            Password = excel.ReadCell("LogInData", 2, 3) ?? "admin";
        }
    }
}