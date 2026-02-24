

using System.Collections.Generic;

namespace PGR_FUND_LABS_CS.CourseProject.GeneratorsLab1
{
    public static class FibonacciGenerator // This class generates an infinite sequence of Fibonacci numbers using an iterator.
    {
        public static IEnumerable<long> Generate() // This method is an iterator that yields Fibonacci numbers indefinitely.
        {
            long a = 0;
            long b = 1;

            while (true)
            {
                yield return a;

                long temp = a;
                a = b;
                b = temp + b;
            }
        }
    }
}


