using System;
using System.Diagnostics;
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

        public T Execute<T>(Func<T> action, LogLevel level, string methodName, params object[] args)
        {
            if (_logger.IsEnabled(level))
                _logger.Log(level, $"Executing: {methodName} | Args: {string.Join(", ", args)}");

            var sw = Stopwatch.StartNew();

            try
            {
                var result = action();

                sw.Stop();

                if (_logger.IsEnabled(level))
                    _logger.Log(level, $"Result: {result} | Time: {sw.ElapsedMilliseconds}ms");

                return result;
            }
            catch (Exception ex)
            {
                sw.Stop();
                _logger.Log(LogLevel.ERROR, $"Error in {methodName}: {ex.Message}");
                throw;
            }
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> action, LogLevel level, string methodName, params object[] args)
        {
            if (_logger.IsEnabled(level))
                _logger.Log(level, $"Executing async: {methodName} | Args: {string.Join(", ", args)}");

            var sw = Stopwatch.StartNew();

            try
            {
                var result = await action();

                sw.Stop();

                if (_logger.IsEnabled(level))
                    _logger.Log(level, $"Result: {result} | Time: {sw.ElapsedMilliseconds}ms");

                return result;
            }
            catch (Exception ex)
            {
                sw.Stop();
                _logger.Log(LogLevel.ERROR, $"Error in async {methodName}: {ex.Message}");
                throw;
            }
        }
    }
}