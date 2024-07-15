using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal class SSWinAppsTestData
    {
        internal string Type { get; set; }
        internal string Name { get; set; }
        internal bool NonSysModule { get; set; }
        internal string BasicModuleType { get; set; }
        internal string PackageName { get; set; }
        internal string ProtocolApplication { get; set; }
        internal string ProjectsApplication { get; set; }
        internal string FileName { get; set; }
        internal bool NamedApp { get; set; }
        internal string Storage { get; set; }

        internal SSWinAppsTestData(int counter = 0)
        {
            Excel excel = new Excel(MainTestData.ExcelFile);
            counter += 2;
            Type = excel.ReadCell("SystemStructureCreateData", counter, 2) ?? "DocProjects";
            Name = excel.ReadCell("SystemStructureCreateData", counter, 3) ?? "Тестовое имя " + Helper.RandomString(new Random(), 5);
            NonSysModule = Convert.ToBoolean(excel.ReadCell("SystemStructureCreateData", counter, 4) ?? "True");
            BasicModuleType = excel.ReadCell("SystemStructureCreateData", counter, 5) ?? "DocProjects";
            PackageName = excel.ReadCell("SystemStructureCreateData", counter, 6) ?? "Тест комплект" + Helper.RandomString(new Random(), 5);
            ProtocolApplication = excel.ReadCell("SystemStructureCreateData", counter, 8) ?? "CC";
            ProjectsApplication = excel.ReadCell("SystemStructureCreateData", counter, 9) ?? "CC";
            FileName = excel.ReadCell("SystemStructureCreateData", counter, 10) ?? "Тестовое имя файла" + Helper.RandomString(new Random(), 5);
            Storage = excel.ReadCell("SystemStructureCreateData", counter, 12) ?? "Domino";
        }
    }
}