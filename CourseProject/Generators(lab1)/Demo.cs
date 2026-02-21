

namespace GeneratorsLab1
{
    class Demo
    {
        static void DemoLab1()
        {
            var fib = FibonacciGenerator.Generate();
            TimeoutIterator.Consume(fib, 5);

        }
    }
}


