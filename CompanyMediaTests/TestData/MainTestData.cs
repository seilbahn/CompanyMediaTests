namespace CompanyMediaTests.TestData
{
    internal static class MainTestData
    {
        public static string ExcelFile { get; }

        static MainTestData()
        {
            ExcelFile = Path.Combine(Environment.CurrentDirectory, "TestData", "TestData.xlsx");
        }
    }
}