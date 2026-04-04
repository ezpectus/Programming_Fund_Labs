using System;
using System.Text.Json;
using PGR_FUND_LABS_CS.CourseProject.LoggerLab9.CoreLab9;

namespace PGR_FUND_LABS_CS.CourseProject.LoggerLab9.Formatters
{
    public class JsonFormatter : ILogFormatter
    {
        public string Format(LogLevel level, string message, DateTime timestamp)
        {
            var logEntry = new
            {
                Timestamp = timestamp.ToString("o"), // ISO 8601
                Level = level.ToString(),
                Message = message
            };
            return JsonSerializer.Serialize(logEntry);
        }
    }
}