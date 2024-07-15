using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal class SSWinOrgsAppsTestData
    {
        internal string Organization { get; set; }
        internal string App { get; set; }

        internal SSWinOrgsAppsTestData(int counter = 0)
        {
            Excel excel = new Excel(MainTestData.ExcelFile);
            counter += 2;
            Organization = excel.ReadCell("SystemStructureCreateOrgsApps", counter, 2) ?? "АдмГор";
            App = excel.ReadCell("SystemStructureCreateOrgsApps", counter, 3) ?? "Тестовое имя 4UFDZEKJ";
        }
    }
}