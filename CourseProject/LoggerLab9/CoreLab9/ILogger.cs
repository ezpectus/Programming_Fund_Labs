namespace PGR_FUND_LABS_CS.CourseProject.LoggerLab9.CoreLab9
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);
        bool IsEnabled(LogLevel level);
    }
}