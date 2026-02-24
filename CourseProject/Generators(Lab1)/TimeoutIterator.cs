using System;
using System.Collections.Generic;

namespace PGR_FUND_LABS_CS.CourseProject.GeneratorsLab1
{
    public static class TimeoutIterator // This class contains a method to consume values from an enumerable generator for a specified duration (in seconds).
    {
        public static void Consume(IEnumerable<long> generator, int seconds)
        {
            var endTime = DateTime.Now.AddSeconds(seconds); // Calculate the end time by adding the specified number of seconds to the current time.

            long sum = 0;
            int count = 0;

            using var enumerator = generator.GetEnumerator(); // Get an enumerator to iterate through the generator.

            while (DateTime.Now < endTime && enumerator.MoveNext()) // Continue iterating as long as the current time is less than the end time and there are more items to consume from the generator.
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


