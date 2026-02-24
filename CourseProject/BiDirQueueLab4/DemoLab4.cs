using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGR_FUND_LABS_CS.CourseProject.BiDirQueueLab4;

namespace PGR_FUND_LABS_CS.CourseProject.BiDirQueueLab4
{
    public static class Lab4Demo
    {
        public static void Run()
        {
            var queue = new BiDirectionalPriorityQueue<string>();

            queue.Enqueue("A", 5);
            queue.Enqueue("B", 1);
            queue.Enqueue("C", 5);
            queue.Enqueue("D", 3);

            Console.WriteLine("Initial state:");
            Console.WriteLine($"PeekOldest: {queue.PeekOldest()}");   // A
            Console.WriteLine($"PeekNewest: {queue.PeekNewest()}");   // D
            Console.WriteLine($"PeekHighest: {queue.PeekHighest()}"); // A
            Console.WriteLine($"PeekLowest: {queue.PeekLowest()}");   // B
            Console.WriteLine();

            Console.WriteLine("Dequeue tests:");

            Console.WriteLine($"DequeueOldest: {queue.DequeueOldest()}"); // A
            Console.WriteLine($"DequeueHighest: {queue.DequeueHighest()}"); // C
            Console.WriteLine($"DequeueLowest: {queue.DequeueLowest()}"); // B
            Console.WriteLine($"DequeueNewest: {queue.DequeueNewest()}"); // D

            Console.WriteLine();
            Console.WriteLine($"IsEmpty: {queue.IsEmpty}"); // True
        }
    }
}

/*
Initial state:
PeekOldest: A
PeekNewest: D
PeekHighest: A
PeekLowest: B

Dequeue tests:
DequeueOldest: A
DequeueHighest: C
DequeueLowest: B
DequeueNewest: D

IsEmpty: True
    */