using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;

namespace CompanyMediaTests.Utility
{
    internal static class Helper
    {
        internal static string GenerateFileName(Reports format, string affix = "", bool onlyNumber = false)
        {
            Random random = new Random();
            StringBuilder name = new StringBuilder();
            if (!onlyNumber)
            {
                try
                {
                    name.Append(DateTime.Now);
                    name.Append(" ");
                    name.Append("Report#");
                    name.Append(new Random().NextInt64());
                    name.Append(RandomString(random, 3));

                    if (format.Equals(Reports.Txt))
                    {
                        name.Append(".txt");
                    }
                    else if (format.Equals(Reports.Excel))
                    {
                        name.Append(".xlsx");
                    }

                    return RemoveInvalidChars(name.ToString());
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentOutOfRangeException || ex is ArgumentNullException || ex is ArgumentException)
                    {
                        name.Clear();
                        name.Append(random.NextInt64());
                    }
                }
            }
            else
            {
                name.Clear();
                name.Append(random.NextInt64());
            }

            return name.ToString();
        }

        internal static string GetProjectName()
        {
            string? name = Assembly.GetCallingAssembly().GetName().Name ?? "CompanyMediaTests";
            name = RemoveInvalidChars(name);

            return name;
        }

        internal static string GetUserName()
        {
            string name;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                name = WindowsIdentity.GetCurrent().Name;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                name = Environment.UserName;
            }
            else
            {
                name = "Unknown";
            }

            return RemoveInvalidChars(name);
        }

        internal static bool IsFolderFileNameValid(string name)
        {
            if (name == null)
            {
                ArgumentNullException argumentNullException =
                    new ArgumentNullException($"The {nameof(name)} is null.");
                throw argumentNullException;
            }
            else if (name.Length == 0)
            {
                ArgumentException argumentException =
                    new ArgumentException($"The {nameof(name)} is empty.");
                throw argumentException;
            }
            else if (name.Length > 255)
            {
                PathTooLongException pathTooLongException =
                    new PathTooLongException($"The {nameof(name)} has more than 255 characters.");
                throw pathTooLongException;
            }
            else if (name.Equals("PRN") ||
                name.Equals("AUX") ||
                name.Equals("NUL") ||
                name.Equals("CON") ||
                name.Equals(".") ||
                name.Equals("..") ||
                name.Equals("CLOCK$") ||
                name.Equals("COM1") ||
                name.Equals("COM2") ||
                name.Equals("COM3") ||
                name.Equals("COM4") ||
                name.Equals("COM5") ||
                name.Equals("COM6") ||
                name.Equals("COM7") ||
                name.Equals("COM8") ||
                name.Equals("COM9") ||
                name.Equals("LPT1") ||
                name.Equals("LPT2") ||
                name.Equals("LPT3") ||
                name.Equals("LPT4") ||
                name.Equals("LPT5") ||
                name.Equals("LPT6") ||
                name.Equals("LPT7") ||
                name.Equals("LPT8") ||
                name.Equals("LPT9"))
            {
                ArgumentException argumentException = new ArgumentException("The following names are not allowed: " +
                    "LPT1, LPT2, LPT3, LPT4, LPT5, LPT6, LPT7, LPT8, LPT9, " +
                    "COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, " +
                    "PRN, AUX, NUL, CON, CLOCK$, dot character (.), and two dot characters (..).");
                throw argumentException;
            }
            else if (HasSpecialChar(name))
            {
                ArgumentException argumentException = new ArgumentException(
                    "Do not use the following reserved characters:\r\n< > : \" / \\ | ? *");
                throw argumentException;
            }
            else if (Path.GetInvalidPathChars().Where(x => name.Contains(x)).Any())
            {
                ArgumentException argumentException = new ArgumentException(
                    "Do not use the invalid path name characters.");
                throw argumentException;
            }
            else if (Path.GetInvalidFileNameChars().Where(x => name.Contains(x)).Any())
            {
                ArgumentException argumentException = new ArgumentException(
                    "Do not use the invalid file name characters.");
                throw argumentException;
            }
            else
            {
                return true;
            }
        }

        internal static bool IsPathValid(string path)
        {
            bool isValid = false;

            try
            {
                if (Path.GetInvalidPathChars().Where(x => path.Contains(x)).Any())
                {
                    throw new ArgumentException($"The {nameof(path)} is empty, " +
                        $"contains only white spaces, or contains invalid characters.");
                }

                path = Path.GetFullPath(path);
                Directory.CreateDirectory(path);
                isValid = true;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException($"{nameof(path)} is null.");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"The {nameof(path)} is empty, " +
                    $"contains only white spaces, or contains invalid characters.");
            }
            catch (SecurityException)
            {
                throw new SecurityException("The caller does not have " +
                    "the required permissions.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException($"Access to {nameof(path)} is denied.");
            }
            catch (DirectoryNotFoundException)
            {
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException($"The {nameof(path)} exceed " +
                    $"the system-defined maximum length.");
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException($"{nameof(path)} contains a colon (:) " +
                    $"in the middle of the string.");
            }
            catch (IOException)
            {
                throw new IOException($"The path {nameof(path)} cannot be used " +
                    $"to create a directory.");
            }
            return isValid;
        }

        internal static string RandomString(Random random, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        internal static string RemoveInvalidChars(string input, string swap = "_")
        {
            string pattern = "[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]";
            return Regex.Replace(input, pattern, swap);
        }

        private static bool HasSpecialChar(string input)
        {
            string specialChar = @"<>:""/\|?*";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static string GetCurrentMethodName()
        {
            StackTrace st = new StackTrace();
            StackFrame? sf = st.GetFrame(1);

            return sf!.GetMethod()!.Name;
        }

        internal static int GetCurrentLineNumber([CallerLineNumber] int lineNumber = 0)
        {
            return lineNumber;
        }

        internal static void OpenDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = path,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
            else
            {
                throw new DirectoryNotFoundException($"The directory {path} was not found.");
            }
        }
    }
}