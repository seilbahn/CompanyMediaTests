using Serilog;
using Serilog.Core;

namespace CompanyMediaTests
{
    internal class Beaver
    {
        public LoggerConfiguration LoggerConfiguration { get; set; }

        public Logger Logger { get; set; }

        public string Path { get; }

        public Beaver(string logFilePath)
        {
            Path = logFilePath;
            LoggerConfiguration = new LoggerConfiguration();
            LoggerConfiguration = LoggerConfiguration.WriteTo.Console().WriteTo.File(logFilePath);
            LoggerConfiguration = LoggerConfiguration.MinimumLevel.Information();
            Logger = LoggerConfiguration.CreateLogger();
        }
    }
}