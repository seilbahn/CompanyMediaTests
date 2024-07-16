using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal class SSWinOrgsCreateWSSTestData
    {
        internal string App { get; set; }

        internal SSWinOrgsCreateWSSTestData(int counter = 0)
        {
            Excel excel = new Excel(MainTestData.ExcelFile);
            counter += 2;
            App = excel.ReadCell("SystemStructureCreateWSS", counter, 2) ?? "Персональные настройки";
        }
    }
}