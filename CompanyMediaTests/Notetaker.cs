using Serilog;
using Serilog.Core;

namespace CompanyMediaTests
{
    /// <summary>
    /// The class Notetaker is designed to
    /// implement logging via the library Serilog.
    /// </summary>
    internal class Notetaker
    {
        /// <summary>
        /// The reference to the class LoggerConfiguration.
        /// </summary>
        public LoggerConfiguration Configuration { get; set; }


        /// <summary>
        /// The reference to the class Logger.
        /// </summary>
        public Logger Logger { get; set; }

        /// <summary>
        /// The path to the log file.
        /// </summary>
        public string Path { get; set; }


        /// <summary>
        /// The constructor initializes a new instance of the class Notetaker.<br/>
        /// </summary>
        /// <param name="logFilePath">
        /// The path to the log file.
        /// </param>
        public Notetaker(string logFilePath)
        {
            Path = logFilePath;
            Configuration = new LoggerConfiguration();
            Configuration = Configuration.WriteTo.Console().WriteTo.File(logFilePath);
            Configuration = Configuration.MinimumLevel.Information();
            Logger = Configuration.CreateLogger();
        }
    }
}