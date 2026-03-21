using System;


namespace PGR_FUND_LABS_CS.CourseProject.LoggerLab9.CoreLab9
{
    public interface ILogFormatter
    {
     string Format(LogLevel level ,string message,DateTime timestamp);

    }
}
