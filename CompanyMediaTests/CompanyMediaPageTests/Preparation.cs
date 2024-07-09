using CompanyMediaTests.Utility;

namespace CompanyMediaTests.CompanyMediaPageTests
{
    [SetUpFixture]
    internal class Preparation
    {
        [OneTimeSetUp]
        public void Prepare()
        {
            if (Directory.Exists(Options.DirectorytPath))
            {
                Directory.Delete(Options.DirectorytPath, true);
            }
            Starting();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
        }

        public static void Starting()
        {
            CheckDir(Options.DirectorytPath);
            CheckDir(Options.LogsDirectoryPath);
            CheckDir(Options.ExcelReportsDirectoryPath);
        }

        private static void CheckDir(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
