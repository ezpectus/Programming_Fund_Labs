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
            Console.WriteLine("=== Lab 9: Logging Decorator ===\n");

            RunConsolePlain();
            RunConsoleJson();
            RunFileLogging();
            RunErrorLevelDemo();
            RunExceptionDemo();

            await RunAsyncDemo();

            Console.WriteLine("\n=== Lab 9 completed ===");
        }

        private static void RunConsolePlain()
        {
            Console.WriteLine("=== Console + Plain ===");

            var logger = new ConsoleLogger(LogLevel.DEBUG, new PlainFormatter());
            var decorator = new LoggingDecorator(logger);

            decorator.Execute(() => 2 + 2, LogLevel.INFO, "Addition", 2, 2);

            Console.WriteLine();
        }

        private static void RunConsoleJson()
        {
            Console.WriteLine("=== Console + JSON ===");

            var logger = new ConsoleLogger(LogLevel.DEBUG, new JsonFormatter());
            var decorator = new LoggingDecorator(logger);

            decorator.Execute(() => "hello".ToUpper(), LogLevel.INFO, "ToUpper", "hello");

            Console.WriteLine();
        }

        private static void RunFileLogging()
        {
            Console.WriteLine("=== File + JSON ===");

            var fileLogger = new FileLogger("lab9.log", LogLevel.DEBUG, new JsonFormatter());
            fileLogger.ClearLog();

            var decorator = new LoggingDecorator(fileLogger);

            decorator.Execute(() => 10 * 5, LogLevel.INFO, "Multiply", 10, 5);

            Console.WriteLine("Log written to file.\n");
        }

        private static void RunErrorLevelDemo()
        {
            Console.WriteLine("=== Only ERROR level ===");

            var logger = new ConsoleLogger(LogLevel.ERROR, new PlainFormatter());
            var decorator = new LoggingDecorator(logger);

            decorator.Execute(() => 1 + 1, LogLevel.DEBUG, "IgnoredDebug", 1, 1);
            decorator.Execute(() => 1 + 1, LogLevel.ERROR, "ErrorOnly", 1, 1);

            Console.WriteLine();
        }

        private static void RunExceptionDemo()
        {
            Console.WriteLine("=== Exception Handling ===");

            var logger = new ConsoleLogger(LogLevel.DEBUG, new PlainFormatter());
            var decorator = new LoggingDecorator(logger);

            try
            {
                decorator.Execute<int>(
                    () => throw new Exception("Test exception"),
                    LogLevel.INFO,
                    "FailingMethod"
                );
            }
            catch
            {
                Console.WriteLine("Exception was caught in demo.\n");
            }
        }

        private static async Task RunAsyncDemo()
        {
            Console.WriteLine("=== Async Execute ===");

            var logger = new ConsoleLogger(LogLevel.DEBUG, new PlainFormatter());
            var decorator = new LoggingDecorator(logger);

            var result = await decorator.ExecuteAsync(
                async () =>
                {
                    await Task.Delay(100);
                    return 42;
                },
                LogLevel.INFO,
                "AsyncOperation",
                "delay=100ms"
            );

            Console.WriteLine($"Async result: {result}\n");
        }
    }
}