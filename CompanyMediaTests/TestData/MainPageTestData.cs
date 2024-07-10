using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal class MainPageTestData
    {
        internal static string Login { get; }
        internal static string Name { get; }
        internal static string Surname { get; }
        internal static string Email { get; }

        static MainPageTestData()
        {
            Excel excel = new Excel(MainTestData.ExcelFile);
            Login = excel.ReadCell("LogInData", 2, 4) ?? "admin";
            Name = excel.ReadCell("LogInData", 2, 5) ?? "admin";
            Surname = excel.ReadCell("LogInData", 2, 6) ?? string.Empty;
            Email = excel.ReadCell("LogInData", 2, 7) ?? "admin@localhost.com";
        }
    }
}