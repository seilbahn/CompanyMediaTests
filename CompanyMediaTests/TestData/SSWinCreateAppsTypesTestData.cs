using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal class SSWinCreateAppsTypesTestData
    {
        internal string Name { get; set; }
        internal string Identifier { get; set; }
        internal bool IsCorporate { get; set; }
        internal bool IsWithModules { get; set; }

        internal SSWinCreateAppsTypesTestData(int counter = 0)
        {
            Excel excel = new Excel(MainTestData.ExcelFile);
            counter += 2;
            Name = excel.ReadCell("SystemStructureCreateAppsTypes", counter, 2) ?? "Тестовое наименование " + Helper.RandomString(new Random(), 5);
            Identifier = excel.ReadCell("SystemStructureCreateAppsTypes", counter, 3) ?? "Тестовый идентификатор " + Helper.RandomString(new Random(), 5);
            IsCorporate = Convert.ToBoolean(excel.ReadCell("SystemStructureCreateAppsTypes", counter, 4) ?? "True");
            IsWithModules = Convert.ToBoolean(excel.ReadCell("SystemStructureCreateAppsTypes", counter, 5) ?? "True");
        }
    }
}