using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PGR_FUND_LABS_CS.CourseProject.BiDirQueueLab4
{
    public class BiDirectionalPriorityQueue<T>
    {
        private readonly SortedDictionary<int, LinkedList<Entry>> priorities;
        private readonly LinkedList<Entry> insertionOrder;
        private long sequenceCounter;
        private class Entry
        {
            public T Item;
            public int Priority;
            public long Sequence;

            public LinkedListNode<Entry> InsertionNode;
            public LinkedListNode<Entry> PriorityNode;
        }

        public BiDirectionalPriorityQueue()
        {
            priorities = new SortedDictionary<int, LinkedList<Entry>>();
            insertionOrder = new LinkedList<Entry>();
            sequenceCounter = 0;
        }
        // Enqueue an item with a given priority

        public void Enqueue(T item, int priority)
        {
            var entry = new Entry
            {
                Item = item,
                Priority = priority,
                Sequence = sequenceCounter++
            };

            var insertionNode = insertionOrder.AddLast(entry);
            entry.InsertionNode = insertionNode;

            if (!priorities.ContainsKey(priority))
                {
                    priorities[priority] = new LinkedList<Entry>();
            }


            var priorityNode = priorities[priority].AddLast(entry);
            entry.PriorityNode = priorityNode;
        }


        public T peekOldest()
        {
            
            if (insertionOrder.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            return insertionOrder.First.Value.Item;

        }


        public T peekNewest()
        {

            if (insertionOrder.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            return insertionOrder.Last.Value.Item;
        }


        public T peekHighest()
        {
            if (priorities.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            var highestPriority = priorities.Keys.Last();
            return priorities[highestPriority].First.Value.Item;
        }
        public T peekLowest()
        {
              if (priorities.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            var lowestPriority = priorities.Keys.First();
            return priorities[lowestPriority].First.Value.Item;
        }


    }
}