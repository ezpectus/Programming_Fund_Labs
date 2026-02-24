using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PGR_FUND_LABS_CS.CourseProject.BiDirQueueLab4
{
    public class BiDirectionalPriorityQueue<T> // A custom data structure that allows for efficient retrieval and removal of items based on both their insertion order and priority
    {
        private readonly SortedDictionary<int, LinkedList<Entry>> priorities;
        private readonly LinkedList<Entry> insertionOrder;
        private long sequenceCounter;
        private sealed class Entry // Represents an item in the queue along with its priority and insertion sequence
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

        public void Enqueue(T item, int priority) // Add an item to the queue with a specified priority
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


        public T PeekOldest() // Get the item that was added first without removing it
        {

            if (insertionOrder.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            return insertionOrder.First.Value.Item;

        }


        public T PeekNewest() // Get the item that was most recently added without removing it
        {

            if (insertionOrder.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            return insertionOrder.Last.Value.Item;
        }


        public T PeekHighest() // Get the item with the highest priority without removing it
        {
            if (priorities.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            var highestPriority = priorities.Keys.Last();
            return priorities[highestPriority].First.Value.Item;
        }
        public T PeekLowest() // Get the item with the lowest priority without removing it
        {
            if (priorities.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            var lowestPriority = priorities.Keys.First();
            return priorities[lowestPriority].First.Value.Item;
        }

        //Dequeue

        public T DequeueOldest() // Remove and return the item that was added first
        {
            if (insertionOrder.Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            var node = insertionOrder.First;
            var entry = node.Value;

            insertionOrder.Remove(node);
            priorities[entry.Priority].Remove(entry.PriorityNode);

            if (priorities[entry.Priority].Count == 0)
                priorities.Remove(entry.Priority);

            return entry.Item;
        }

        public T DequeueNewest() // Remove and return the item that was most recently added
        {
            if (insertionOrder.Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            var node = insertionOrder.Last;
            var entry = node.Value;

            insertionOrder.Remove(node);
            priorities[entry.Priority].Remove(entry.PriorityNode);

            if (priorities[entry.Priority].Count == 0)
                priorities.Remove(entry.Priority);

            return entry.Item;
        }

        public T DequeueHighest() // Remove and return the item with the highest priority
        {
            if (priorities.Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            var highestPriority = priorities.Keys.Last();
            var node = priorities[highestPriority].First;
            var entry = node.Value;

            priorities[highestPriority].Remove(node);
            insertionOrder.Remove(entry.InsertionNode);

            if (priorities[highestPriority].Count == 0)
                priorities.Remove(highestPriority);

            return entry.Item;
        }

        public T DequeueLowest() // Remove and return the item with the lowest priority
        {
            if (priorities.Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            var lowestPriority = priorities.Keys.First();
            var node = priorities[lowestPriority].First;
            var entry = node.Value;

            priorities[lowestPriority].Remove(node);
            insertionOrder.Remove(entry.InsertionNode);

            if (priorities[lowestPriority].Count == 0)
                priorities.Remove(lowestPriority);

            return entry.Item;

        }

         public int Count => insertionOrder.Count; // Get the total number of items in the queue
         public bool IsEmpty => Count == 0; // Check if the queue is empty


    }
}