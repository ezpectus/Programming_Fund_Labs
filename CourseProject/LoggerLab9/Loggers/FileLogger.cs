using System;
using System.IO;
using PGR_FUND_LABS_CS.CourseProject.LoggerLab9.CoreLab9;

namespace PGR_FUND_LABS_CS.CourseProject.LoggerLab9.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        private readonly LogLevel _minLogLevel;
        private readonly ILogFormatter _formatter;

        public FileLogger(string filePath, LogLevel minLogLevel, ILogFormatter formatter)
        {
            _filePath = filePath;
            _minLogLevel = minLogLevel;
            _formatter = formatter;
        }

        public bool IsEnabled(LogLevel level) => level >= _minLogLevel;

        public void Log(LogLevel level, string message)
        {
            if (!IsEnabled(level)) return;
            var logEntry = _formatter.Format(level, message, DateTime.Now);
            File.AppendAllText(_filePath, logEntry + Environment.NewLine);
        }

        public void ClearLog()
        {
            File.WriteAllText(_filePath, string.Empty);
        }
    }
}


