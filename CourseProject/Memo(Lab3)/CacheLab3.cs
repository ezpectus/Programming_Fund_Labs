using CourseProject.MemoLab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PGR_FUND_LABS_CS.CourseProject.Memo_Lab3_
{
    class CacheLab3
    {
        public static void Run()
        {
            Console.WriteLine(" LRU WITH TTL DEMO ");

            var lru = new LRUCache(2, TimeSpan.FromSeconds(3));

            lru.Set("A", "Apple");
            Console.WriteLine("Inserted A");

            lru.Set("B", "Banana");
            Console.WriteLine("Inserted B");

            if (lru.TryGet("A", out var valA))
                Console.WriteLine("Access A -> " + valA);

            lru.Set("C", "Cherry");
            Console.WriteLine("Inserted C (capacity exceeded)");

            if (!lru.TryGet("B", out _))
                Console.WriteLine("Access B -> null (evicted)");

            Console.WriteLine("Waiting for TTL expiration...");
            Thread.Sleep(4000);

            if (!lru.TryGet("A", out _))
                Console.WriteLine("Access A after TTL -> null (expired)");



            Console.WriteLine("\n LFU DEMO ");

            var lfu = new LFUCache(2);

            lfu.Set("A", "Apple");
            Console.WriteLine("Inserted A");

            lfu.Set("B", "Banana");
            Console.WriteLine("Inserted B");

            lfu.TryGet("A", out _);
            lfu.TryGet("A", out _);
            Console.WriteLine("Accessed A twice");

            lfu.Set("C", "Cherry");
            Console.WriteLine("Inserted C (LFU eviction expected)");

            if (!lfu.TryGet("B", out _))
                Console.WriteLine("Access B -> null (evicted)");

            if (lfu.TryGet("A", out var val))
                Console.WriteLine("Access A -> " + val);
        }
    }
}


