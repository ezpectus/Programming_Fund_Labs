using System;
using PGR_FUND_LABS_CS.CourseProject.LoggerLab9.CoreLab9;

namespace PGR_FUND_LABS_CS.CourseProject.LoggerLab9.Loggers
{
    public class ConsoleLogger : ILogger
    {
        private readonly LogLevel _minLogLevel;
        private readonly ILogFormatter _formatter;

        public ConsoleLogger(LogLevel minLogLevel, ILogFormatter formatter)
        {
            _minLogLevel = minLogLevel;
            _formatter = formatter;
        }

        public bool IsEnabled(LogLevel level) => level >= _minLogLevel;

        public void Log(LogLevel level, string message)
        {
            if (!IsEnabled(level)) return;
            Console.WriteLine(_formatter.Format(level, message, DateTime.Now));
        }
    }
}