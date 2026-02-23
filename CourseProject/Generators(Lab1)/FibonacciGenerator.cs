

using System.Collections.Generic;

namespace PGR_FUND_LABS_CS.CourseProject.GeneratorsLab1
{
    public static class FibonacciGenerator
    {
        public static IEnumerable<long> Generate()
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


