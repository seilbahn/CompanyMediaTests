using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal class LogInPageTestData
    {
        internal string UserName { get; }
        internal string Password { get; }
        internal string Login { get; }
        internal string Name { get; }
        internal string Surname { get; }
        internal string Email { get; }
        internal bool IsValid { get; }

        internal LogInPageTestData(bool isValid)
        {
            Excel excel = new Excel(MainTestData.ExcelFile);

            if (isValid)
            {
                UserName = excel.ReadCell("LogInData", 2, 2) ?? "admin";
                Password = excel.ReadCell("LogInData", 2, 3) ?? "admin";
                Login = excel.ReadCell("LogInData", 2, 4) ?? "admin";
                Name = excel.ReadCell("LogInData", 2, 5) ?? "admin";
                Surname = excel.ReadCell("LogInData", 2, 6) ?? string.Empty;
                Email = excel.ReadCell("LogInData", 2, 7) ?? "admin@localhost.com";
                IsValid = Convert.ToBoolean(excel.ReadCell("LogInData", 2, 8) ?? "True");
            }
            else
            {
                UserName = excel.ReadCell("LogInData", 3, 2) ?? "domino";
                Password = excel.ReadCell("LogInData", 3, 3) ?? "lotus";
                Login = excel.ReadCell("LogInData", 3, 4) ?? "qwertz";
                Name = excel.ReadCell("LogInData", 3, 5) ?? "qwertz";
                Surname = excel.ReadCell("LogInData", 3, 6) ?? "qwertz";
                Email = excel.ReadCell("LogInData", 3, 7) ?? "qwertz@qwertz.com";
                IsValid = Convert.ToBoolean(excel.ReadCell("LogInData", 3, 8) ?? "False");
            }
        }
    }
}