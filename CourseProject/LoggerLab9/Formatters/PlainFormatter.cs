using System;
using PGR_FUND_LABS_CS.CourseProject.LoggerLab9.CoreLab9;

namespace PGR_FUND_LABS_CS.CourseProject.LoggerLab9.Formatters
{
    public  class PlainFormatter : ILogFormatter
    {

        public string Format(LogLevel level, string message, DateTime timestamp)
        {
            return $"[{timestamp:yyyy-MM-dd HH:mm:ss}] {level}: {message}";
        }
    }
}
