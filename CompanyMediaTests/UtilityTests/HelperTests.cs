using CompanyMediaTests.Utility;

namespace CompanyMediaTests.UtilityTests
{
    internal class HelperTests
    {
        private string fileName;
        private string directoryPath;
        private string filePath;
        private string validPath = @"E:\123\456\abc";
        private string invalidPath = @"E:\a:c\def";
        private string validFolderName = "abc123";
        private string invalidFolderName = "AUX";

        [SetUp]
        public void Setup()
        {
            fileName = string.Empty;
            directoryPath = Path.Combine(Environment.CurrentDirectory, "TestFiles");
            filePath = string.Empty;

            Directory.CreateDirectory(directoryPath);
        }

        [Test, Repeat(1000)]
        public void GenerateFileNameTest()
        {
            bool isNameValidViaPath = false;
            bool isNameValidViaCreate = false;
            bool isNameValid = false;

            fileName = Helper.GenerateFileName(Reports.Excel);
            isNameValidViaPath = !Path.GetInvalidPathChars().Where(x => fileName.Contains(x)).Any();

            try
            {
                Directory.CreateDirectory(directoryPath);
                filePath = Path.Combine(directoryPath, fileName);
                File.Create(filePath).Close();
                isNameValidViaCreate = File.Exists(filePath);
            }
            catch
            {
                isNameValidViaCreate = false;
            }

            isNameValid = isNameValidViaPath && isNameValidViaCreate;
            Assert.IsTrue(isNameValid);
        }

        [Test, Repeat(1000)]
        public void IsFolderNameValidTest()
        {
            bool isValid;
            try
            {
                isValid = Helper.IsFolderFileNameValid(validFolderName);
            }
            catch { }
            try
            {
                isValid = !Helper.IsFolderFileNameValid(invalidFolderName);
            }
            catch
            {
                isValid = true;
            }
            Assert.IsTrue(isValid);
        }

        [Test, Repeat(1000)]
        public void IsPathValidTest()
        {
            bool isValid;
            try
            {
                isValid = Helper.IsPathValid(validPath) && validPath.IndexOfAny(Path.GetInvalidPathChars()) == -1;
            }
            catch
            {
                isValid = false;
            }

            bool isInvalid;
            try
            {
                isInvalid = !Helper.IsPathValid(invalidPath) && !(invalidPath.IndexOfAny(Path.GetInvalidPathChars()) == -1);
            }
            catch
            {
                isInvalid = true;
            }
            Directory.Delete(@"E:\123\", true);
            Assert.IsTrue(isValid && isInvalid);
        }

        [Test, Repeat(1000)]
        public void RemoveInvalidChairsTest()
        {
            string a = "1<2>3:4\"5/6\\7|8?9*";
            string b = "123456789";
            Assert.That(Helper.RemoveInvalidChars(a, ""), Is.EqualTo(b));
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(directoryPath, true);            
        }
    }
}