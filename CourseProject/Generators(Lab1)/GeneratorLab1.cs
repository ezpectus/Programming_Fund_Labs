using System;

namespace PGR_FUND_LABS_CS.CourseProject.GeneratorsLab1
{
    class DemoLab1
    {
        public static void Run() // This method demonstrates the use of the Fibonacci generator and a timeout iterator to consume a finite number of Fibonacci numbers.
        {
            var fib = FibonacciGenerator.Generate();
            TimeoutIterator.Consume(fib, 5);
        }
    }
}


