using CompanyMediaTests.Utility;
using OfficeOpenXml;

namespace CompanyMediaTests.UtilityTests
{
    internal class ExcelTests
    {
        private string fileName;
        private string directoryPath;
        private string filePath;

        private readonly string[] strings = [ "QCNp+2VnsB]F`f\"6R}5{3Hy(ZX-c*[?wA>=x_P)%jMze';K87a",
                                              "F&he+j/t-@>!5QX$k9x%yTK8Gm=n(JM],:z_L6vCZ}g;U\"?W['",
                                              "T~;_)*rB2EGm`uCF3A$(+9,b6QDeY8!xJ?W<^cay/g4P-\"57tZ",
                                              "FMqO3wojqUBaiqS4IQtmhNLHi",
                                              "AD9oHN8sfsE7aHTIu1e8BHmlW",
                                              "rgllNbNvK5kRghgm6UfusYQcZ",
                                              "Test Sheet #805",
                                              "Test Sheet #806"];

        [SetUp]
        public void Setup()
        {
            fileName = "TestFile.xlsx";
            directoryPath = Path.Combine(Environment.CurrentDirectory, "TestData");
            filePath = Path.Combine(directoryPath, fileName);
            Directory.CreateDirectory(directoryPath);
            File.Create(filePath).Close();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath));
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(strings[6]);
            for (int i = 1; i <= strings.Length; i++)
            {
                worksheet.Cells[i, i].Value = strings[i - 1];
            }
            excelPackage.Save();
        }

        [Test, Repeat(1000)]
        public void CreateExcelInstance()
        {
            Excel excel = new Excel(filePath);
            bool check = excel is Excel && excel.ExcelFilePath == filePath;
            Assert.IsTrue(check);
        }

        [Test, Repeat(1000)]
        public void ReadExcelCell()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath));
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[strings[6]];
            string?[] values = Enumerable.Range(1, 8).Select(i => worksheet.Cells[i, i].Value?.ToString()).ToArray();
            bool arraysEqual = values.SequenceEqual(strings);
            Assert.IsTrue(arraysEqual);
        }

        [Test, Repeat(1000)]
        public void WriteExcelCell()
        {
            string[] newStrings = new string[strings.Length];
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath));
            ExcelWorksheet worksheet;


            // Writing
            if (excelPackage.Workbook.Worksheets.Any(_sheet => _sheet.Name == strings[7]))
            {
                worksheet = excelPackage.Workbook.Worksheets[strings[7]];
            }
            else
            {
                worksheet = excelPackage.Workbook.Worksheets.Add(strings[7]);
            }
            for (int i = 1; i <= strings.Length; i++)
            {
                newStrings[i - 1] = strings[i - 1].Substring(3, strings[i - 1].Length - 3);
                worksheet.Cells[i, i].Value = newStrings[i - 1];
            }
            excelPackage.Save();

            // Reading
            string?[] values = Enumerable.Range(1, 8).Select(i => worksheet.Cells[i, i].Value?.ToString()).ToArray();

            bool arraysEqual = values.SequenceEqual(newStrings);
            Assert.IsTrue(arraysEqual);
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(directoryPath, true);
        }
    }
}