using System;
using PGR_FUND_LABS_CS.CourseProject.LoggerLab9.CoreLab9;

namespace PGR_FUND_LABS_CS.CourseProject.LoggerLab9.Loggers
{
   public class ConsoleLogger : ILogger 
    {
        private readonly LogLevel _minlogLevel;
        private readonly ILogFormatter _logFormatter;
        public ConsoleLogger(LogLevel minlogLevel, ILogFormatter logFormatter)
        {
            _minlogLevel = minlogLevel;
            _logFormatter = logFormatter;
        }
        public bool IsEnabled(LogLevel level) => level >= _minlogLevel;
        public void Log(LogLevel level, string message)
        {
            if (!IsEnabled(level))
                return;
            var formattedMessage = _logFormatter.Format(level, message, DateTime.Now);
            Console.WriteLine(formattedMessage);
        }

    }
}
