using OfficeOpenXml;

namespace CompanyMediaTests.Utility
{
    internal class Reporter
    {
        public string ExcelFilePath { get; set; }

        public Reporter(string path)
        {
            ExcelFilePath = path;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets.Add("Report information");
            workSheet.Cells[1, 1].Value = $"The report was generated automatically at {DateTime.Now}";
            excelPackage.SaveAs(new FileInfo(ExcelFilePath));
        }

        public void Create(List<(string, int, string, string, string)> units)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using ExcelPackage excelPackage = new ExcelPackage(new FileInfo(ExcelFilePath));

            ExcelWorksheet worksheet;
            if (excelPackage.Workbook.Worksheets.Any(_sheet => _sheet.Name == units[0].Item1))
            {
                worksheet = excelPackage.Workbook.Worksheets[units[0].Item1];
            }
            else
            {
                worksheet = excelPackage.Workbook.Worksheets.Add(units[0].Item1);
            }

            for (int i = 0; i < units.Count; i++)
            {
                if (excelPackage.Workbook.Worksheets.Any(_sheet => _sheet.Name == units[i].Item1))
                {
                    worksheet = excelPackage.Workbook.Worksheets[units[i].Item1];
                }
                else
                {
                    worksheet = excelPackage.Workbook.Worksheets.Add(units[i].Item1);
                }

                int currentRow = 2;
                while (!string.IsNullOrEmpty(worksheet.Cells[currentRow, 1].Text))
                {
                    currentRow++;
                }

                worksheet.Cells[1, 1].Value = "#";
                worksheet.Cells[1, 2].Value = "Test";
                worksheet.Cells[1, 3].Value = "Result";
                worksheet.Cells[1, 4].Value = "Log link";

                int row = currentRow;

                worksheet.Cells[row, 1].Value = units[i].Item2;
                worksheet.Cells[row, 2].Value = units[i].Item3;
                worksheet.Cells[row, 3].Value = units[i].Item4;

                string path = units[i].Item5;
                ExcelHyperLink hyperlink = new ExcelHyperLink(path);
                hyperlink.Display = "File";
                worksheet.Cells[row, 4].Hyperlink = hyperlink;
                worksheet.Cells[row, 4].Style.Font.UnderLine = true;

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                worksheet.Cells.AutoFitColumns();
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            worksheet.Cells.AutoFitColumns();
            excelPackage.Save();
        }
    }
}