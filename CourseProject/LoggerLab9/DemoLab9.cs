using System;
using System.Threading.Tasks;
using PGR_FUND_LABS_CS.CourseProject.LoggerLab9.CoreLab9;
using PGR_FUND_LABS_CS.CourseProject.LoggerLab9.Formatters;
using PGR_FUND_LABS_CS.CourseProject.LoggerLab9.Loggers;

namespace PGR_FUND_LABS_CS.CourseProject.LoggerLab9
{
    public class DemoLab9
    {
        public static async Task Run()
        {

            //ConsoleLogger + PlainFormatter
            Console.WriteLine("=== Console + Plain ===");
            var plainLogger = new ConsoleLogger(LogLevel.DEBUG, new PlainFormatter());
            var decorator1 = new LoggingDecorator(plainLogger);
            decorator1.Execute(() => 2 + 2, LogLevel.INFO, "Addition");

            //ConsoleLogger + JsonFormatter
            Console.WriteLine("\n=== Console + JSON ===");
            var jsonLogger = new ConsoleLogger(LogLevel.DEBUG, new JsonFormatter());
            var decorator2 = new LoggingDecorator(jsonLogger);
            decorator2.Execute(() => "hello".ToUpper(), LogLevel.INFO, "ToUpper");

            //FileLogger + JsonFormatter
            Console.WriteLine("\n=== File + JSON ===");
            var fileLogger = new FileLogger("lab9.log", LogLevel.DEBUG, new JsonFormatter());
            var decorator3 = new LoggingDecorator(fileLogger);
            decorator3.Execute(() => 10 * 5, LogLevel.INFO, "Multiply");

            //Only ERROR level
            Console.WriteLine("\n=== Only ERROR level ===");
            var errorLogger = new ConsoleLogger(LogLevel.ERROR, new PlainFormatter());
            var decorator4 = new LoggingDecorator(errorLogger);
            decorator4.Execute(() => 1 + 1, LogLevel.DEBUG, "IgnoredDebug");
            decorator4.Execute(() => 1 + 1, LogLevel.ERROR, "ErrorOnly");

            //AsyncExecute
            Console.WriteLine("\n=== Async Execute ===");
            await decorator1.ExecuteAsync(
                async () => { await Task.Delay(100); return 42; },
                LogLevel.INFO,
                "AsyncOperation"
            );
        }
    }
}