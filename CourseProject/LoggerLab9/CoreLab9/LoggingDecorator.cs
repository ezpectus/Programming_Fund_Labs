

using System;
using System.Threading.Tasks;

namespace PGR_FUND_LABS_CS.CourseProject.LoggerLab9.CoreLab9
{
   public class LoggingDecorator
    {
        private readonly ILogger _logger;
        public LoggingDecorator(ILogger logger)
        {
            _logger = logger;
        }

        public T Execute<T>(Func<T> action, LogLevel level, string methodName)
        {
            _logger.Log(level, $"Executing: {methodName}");
            var start = DateTime.Now;
            var result = action();
            var duration = DateTime.Now - start;
            _logger.Log(level, $"Result: {result}, Time: {duration.TotalMilliseconds}ms");
            return result;
        }
       
        public async Task<T> ExecuteAsync<T>(Func<Task<T>> action, LogLevel level, string methodName)
        {
            _logger.Log(level, $"Executing: {methodName}");
            var start = DateTime.Now;
            var result = await action();
            var duration = DateTime.Now - start;
            _logger.Log(level, $"Result: {result}, Time: {duration.TotalMilliseconds}ms");
            return result;
        }

    }
}
