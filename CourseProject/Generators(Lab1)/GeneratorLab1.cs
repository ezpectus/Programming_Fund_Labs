using System;

namespace PGR_FUND_LABS_CS.CourseProject.GeneratorsLab1
{
    class DemoLab1
    {
        public static void Run()
        {
            var fib = FibonacciGenerator.Generate();
            TimeoutIterator.Consume(fib, 5);
        }
    }
}


