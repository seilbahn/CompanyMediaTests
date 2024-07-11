using CompanyMediaTests.Utility;

namespace CompanyMediaTests.TestData
{
    internal class SystemStructureWindowTestData
    {
        internal string Type { get; }
        internal string Name { get; }
        internal bool NonSysModule { get; }
        internal string BasicModuleType { get; }
        internal string PackageName { get; }
        internal string ProtocolApplication { get; }
        internal string ProjectsApplication { get; }
        internal string FileName { get; }
        internal bool NamedApp { get; }
        internal string Storage { get; }

        internal SystemStructureWindowTestData(int counter = 0)
        {
            Excel excel = new Excel(MainTestData.ExcelFile);
            counter += 2;
            Type = excel.ReadCell("SystemStructureCreateData", counter, 2) ?? "DocProjects";
            Name = excel.ReadCell("SystemStructureCreateData", counter, 3) ?? "Тестовое имя " + Helper.RandomString(new Random(), 5);
            NonSysModule = Convert.ToBoolean(excel.ReadCell("SystemStructureCreateData", counter, 4) ?? "False");
            BasicModuleType = excel.ReadCell("SystemStructureCreateData", counter, 5) ?? "DocProjects";
            PackageName = excel.ReadCell("SystemStructureCreateData", counter, 6) ?? "Тест комплект" + Helper.RandomString(new Random(), 5);
            ProtocolApplication = excel.ReadCell("SystemStructureCreateData", counter, 8) ?? "CC";
            ProjectsApplication = excel.ReadCell("SystemStructureCreateData", counter, 9) ?? "CC";
            FileName = excel.ReadCell("SystemStructureCreateData", counter, 10) ?? "Тестовое имя файла" + Helper.RandomString(new Random(), 5);
            Storage = excel.ReadCell("SystemStructureCreateData", counter, 11) ?? "AF5";
        }
    }
}