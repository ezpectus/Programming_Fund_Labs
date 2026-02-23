using System;
using System.Collections.Generic;

namespace PGR_FUND_LABS_CS.CourseProject.GeneratorsLab1
{
    public static class TimeoutIterator
    {
        public static void Consume(IEnumerable<long> generator, int seconds)
        {
            var endTime = DateTime.Now.AddSeconds(seconds);

            long sum = 0;
            int count = 0;

            using var enumerator = generator.GetEnumerator();

            while (DateTime.Now < endTime && enumerator.MoveNext())
            {
                var item = enumerator.Current;

                Console.WriteLine(item);

                sum += item;
                count++;
            }

            Console.WriteLine("-----");
            Console.WriteLine($"Generated values: {count}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {(count > 0 ? sum / (double)count : 0)}");
        }
    }
}


