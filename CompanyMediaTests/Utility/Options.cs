namespace CompanyMediaTests.Utility
{
    /// <summary>
    /// The class Options provides a point to control
    /// the global settings of the app. It includes such settings as:
    /// a directory name - the name of the folder for reports;
    /// a directory path - the absolute path to the directory;
    /// a project name - the name of the app from this VS-project.
    /// </summary>
    internal static class Options
    {
        private static string directoryName;

        /// <summary>
        /// The property DirectoryName represents the directory 
        /// which is supposed to store report files.<br/>
        /// It should not contain any forbidden characters or otherwise 
        /// while setting this property there may occur an exception.<br/>
        /// <value>The default value is a string like 
        /// "Reports_ProjectName_DateTime.Today"</value>
        /// </summary>
        public static string DirectoryName
        {
            get
            {
                return directoryName;
            }
            set
            {
                string name = value;
                if (Helper.IsFolderFileNameValid(name))
                {
                    directoryName = name;
                }
            }
        }

        private static string directorytPath;

        /// <summary>
        /// The property DirectoryPath represents the path to the directory 
        /// where is supposed to store report files.<br/>
        /// It includes the full path to the directory with the new created folder.<br/>
        /// It should not contain any forbidden characters or otherwise
        /// while setting this property there may occur an exception.<br/>
        /// <value>The default value is the directory My Documents.</value> 
        /// </summary>
        public static string DirectorytPath
        {
            get
            {
                return directorytPath;
            }
            set
            {
                string path = value;
                if (Helper.IsPathValid(path))
                {
                    directorytPath = path;
                }
            }
        }

        private static string projectName;

        /// <summary>
        /// The property ProjectName represents the name of this project.
        /// This name can be used as a name of a file.<br/>
        /// This name should not contain any forbidden characters or otherwise
        /// while setting this property there may occur an exception.<br/>
        /// <value>The default value is the project name.</value>
        /// </summary>
        public static string ProjectName
        {
            get
            {
                return projectName;
            }
            set
            {
                string name = value;
                if (Helper.IsFolderFileNameValid(name))
                {
                    projectName = name;
                }
            }
        }

        /// <summary>
        /// The property StandardDirectory represents My Documents directory.
        /// </summary>
        public static string StandardDirectory { get; }

        /// <summary>
        /// The property LogsDirectoryName represents the name for the logs directory.
        /// </summary>
        public static string LogsDirectoryName { get; }

        /// <summary>
        /// The property LogsDirectoryPath represents the path to the logs directory.
        /// </summary>
        public static string LogsDirectoryPath { get; }

        /// <summary>
        /// The property ExcelReportsDirectoryName represents the name for the excel reports directory.
        /// </summary>
        public static string ExcelReportsDirectoryName { get; }

        /// <summary>
        /// The property ExcelReportsDirectoryPath represents the path to the excel reports directory.
        /// </summary>
        public static string ExcelReportsDirectoryPath { get; }

        /// <summary>
        /// The property LogFileName represents the name for the .txt-file,
        /// which is used for logs.
        /// </summary>
        public static string LogFileName { get; }

        /// <summary>
        /// The property ExcelFileName represents the name for the excel-file,
        /// which is used for reports.
        /// </summary>
        public static string ExcelFileName { get; }

        static Options()
        {
            directoryName = string.Empty;
            directorytPath = string.Empty;
            projectName = string.Empty;

            ProjectName = Helper.GetProjectName();
            DirectoryName = Helper.RemoveInvalidChars($"{ProjectName}" + $" Selenium Test Reports", "");
            StandardDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DirectorytPath = Path.Combine(StandardDirectory, DirectoryName);
            LogsDirectoryName = "Logs";
            LogsDirectoryPath = Path.Combine(DirectorytPath, LogsDirectoryName);
            ExcelReportsDirectoryName = "Excel reports";
            ExcelReportsDirectoryPath = Path.Combine(DirectorytPath, ExcelReportsDirectoryName);
            LogFileName = Helper.GenerateFileName(Reports.Txt);
            ExcelFileName = Helper.GenerateFileName(Reports.Excel);
        }
    }
}