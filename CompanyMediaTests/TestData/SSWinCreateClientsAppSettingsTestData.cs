using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal class SSWinCreateClientsAppSettingsTestData
    {
        internal string App { get; set; }
        internal string ClientsAppType { get; set; }

        internal SSWinCreateClientsAppSettingsTestData(int counter = 0)
        {
            Excel excel = new Excel(MainTestData.ExcelFile);
            counter += 2;
            App = excel.ReadCell("SystemStructureCreateClientApp", counter, 2) ?? "Персональные настройки";
            ClientsAppType = excel.ReadCell("SystemStructureCreateClientApp", counter, 3) ?? "Тип клиентского приложения 1";
        }
    }
}