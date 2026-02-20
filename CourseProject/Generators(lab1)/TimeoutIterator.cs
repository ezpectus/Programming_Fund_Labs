using System;
using System.Collections.Generic;

namespace GeneratorsLab1
{
    public static class TimeoutIterator
    {
        public static void Consume(IEnumerable<long> generator, int seconds)
        {
            var endTime = DateTime.Now.AddSeconds(seconds);

            long sum = 0;
            int count = 0;

            foreach (var item in generator)
            {
                if (DateTime.Now >= endTime)
                    break;

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


