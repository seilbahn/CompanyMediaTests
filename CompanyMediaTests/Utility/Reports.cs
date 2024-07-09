namespace CompanyMediaTests.Utility
{
    /// <summary>
    /// The enumeration Reports represents
    /// types of the report.
    /// </summary>
    [Flags]
    internal enum Reports : byte
    {
        /// <summary>
        /// The .txt-file type of the report.
        /// </summary>
        Txt = 0b_0000,
        /// <summary>
        /// The .xlsx-file type of the report.
        /// </summary>
        Excel = 0b_0001
    }
}