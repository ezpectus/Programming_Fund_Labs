using System;

namespace GeneratorsLab1
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


