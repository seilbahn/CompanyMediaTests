using OfficeOpenXml;

namespace CompanyMediaTests.Utility
{
    /// <summary>
    /// The class Excel is created for RW-operations
    /// with .xlsx- and .xls-files.<br/>
    /// There are only two operations:<br/>
    /// 1) Read a cell;<br/>
    /// 2) Write to a cell.<br/> 
    /// </summary>
    internal class Excel
    {
        /// <summary>
        /// A private field for ExcelFilePath.
        /// </summary>
        private string excelFilePath;

        /// <summary>
        /// The property ExcelFilePath represents a full path
        /// to an existing .xlsx- or .xls-file.<br/>
        /// </summary>
        public string ExcelFilePath
        {
            get
            {
                return excelFilePath;
            }

            set
            {
                string filePath = value;
                string fileExtension = Path.GetExtension(filePath);
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("The file does not exist.");
                }
                else if (!(fileExtension.Equals(".xlsx") || fileExtension.Equals(".xls")))
                {
                    throw new NotSupportedException("The file has an unsupported format. " +
                      "It should have .xlsx- or .xls-extension.");
                }
                else
                {
                    excelFilePath = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the Excel class.
        /// </summary>
        /// <param name="path">A full path to an existing
        /// .xlsx- or .xls-file.</param>
        public Excel(string path)
        {
            excelFilePath = string.Empty;
            ExcelFilePath = path;
        }

        /// <summary>
        /// The method ReadCell reads the contents
        /// of the cell and returns a string value.
        /// </summary>
        /// <param name="sheet">The name of the sheet from
        /// which is supposed to read.</param>
        /// <param name="row">The number of the cell row.</param>
        /// <param name="column">The number of the cell column.</param>
        /// <returns>The read value. It might also be a Null value
        /// if the cell was empty.</returns>
        public string? ReadCell(string sheet, int row, int column)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage excelPackage = new ExcelPackage(new FileInfo(excelFilePath));
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[sheet];
            string? cellValue = worksheet.Cells[row, column].Value?.ToString();
            return cellValue;
        }

        /// <summary>
        /// The method WriteCell tries to write a string to a cell.
        /// </summary>
        /// <param name="sheet">The name of the sheet to
        /// which is supposed to write.<br/>
        /// If the sheet does not exist the method creates a new one
        /// with the same name.</param>
        /// <param name="row">The neumber of the cell row.</param>
        /// <param name="column">The number of the cell column.</param>
        /// <param name="value">The value to be written to the cell.</param>
        /// <returns>True - if the writing if successful,</br>
        /// False - if </returns>
        public bool WriteCell(string sheet, int row, int column, string value)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using ExcelPackage excelPackage = new ExcelPackage(new FileInfo(excelFilePath));

            ExcelWorksheet worksheet;
            if (excelPackage.Workbook.Worksheets.Any(_sheet => _sheet.Name == sheet))
            {
                worksheet = excelPackage.Workbook.Worksheets[sheet];
            }
            else
            {
                worksheet = excelPackage.Workbook.Worksheets.Add(sheet);
            }

            worksheet.Cells[row, column].Value = value;
            excelPackage.Save();
            return value.Equals(worksheet.Cells[row, column].Value.ToString());
        }
    }
}