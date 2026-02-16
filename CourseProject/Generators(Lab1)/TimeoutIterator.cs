
using System;
using System.Collections.Generic;

namespace GeneratorsLab1;

public static class TimeoutIterator
{
    public static void Consume<T>(IEnumerable<T> generator, int seconds)
    {
        var endTime = DateTime.Now.AddSeconds(seconds);

        foreach (var item in generator)
        {
            if (DateTime.Now >= endTime)
                break;

            Console.WriteLine(item);
        }
    }
}
