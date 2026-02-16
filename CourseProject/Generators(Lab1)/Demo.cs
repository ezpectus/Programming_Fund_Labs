namespace GeneratorsLab1;

namespace GeneratorsLab1;

class Program
{
    static void Main()
    {
        var fib = FibonacciGenerator.Generate();
        TimeoutIterator.Consume(fib, 5);
    }
}
