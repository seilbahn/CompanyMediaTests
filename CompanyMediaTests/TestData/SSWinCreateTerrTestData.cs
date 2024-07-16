using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal class SSWinCreateTerrTestData
    {
        internal string Organization { get; set; }
        internal string Identifier { get; set; }
        internal string Name { get; set; }
        internal bool IsCentral { get; set; }
        internal string Prefix { get; set; }
        internal int GroupAccessCounter { get; set; }
        internal bool IsCentralTerrTimeZoneUsed { get; set; }
        internal string TimeZone { get; set; }
        internal string Heading { get; set; }
        internal bool IsSummerTimeUsed { get; set; }

        internal SSWinCreateTerrTestData(int counter = 0)
        {
            Excel excel = new Excel(MainTestData.ExcelFile);
            counter += 2;
            Organization = excel.ReadCell("SystemStructureCreateTerr", counter, 2) ?? "АдмГор";
            Identifier = excel.ReadCell("SystemStructureCreateTerr", counter, 3) ?? "Test_identifier_2101" + Helper.RandomString(new Random(), 5);
            Name = excel.ReadCell("SystemStructureCreateTerr", counter, 4) ?? "Тестовое название 09" + Helper.RandomString(new Random(), 5);
            IsCentral = Convert.ToBoolean(excel.ReadCell("SystemStructureCreateTerr", counter, 5) ?? "False");
            Prefix = excel.ReadCell("SystemStructureCreateTerr", counter, 6) ?? "d1";
            GroupAccessCounter = Convert.ToInt32(excel.ReadCell("SystemStructureCreateTerr", counter, 7));
            IsCentralTerrTimeZoneUsed = Convert.ToBoolean(excel.ReadCell("SystemStructureCreateTerr", counter, 8) ?? "True");
            TimeZone = excel.ReadCell("SystemStructureCreateTerr", counter, 9) ?? "0";
            Heading = excel.ReadCell("SystemStructureCreateTerr", counter, 10) ?? "0";
            IsSummerTimeUsed = Convert.ToBoolean(excel.ReadCell("SystemStructureCreateTerr", counter, 11) ?? "False");
        }
    }
}
