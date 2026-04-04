using System;
using System.Collections.Generic;
using System.Linq;

namespace PGR_FUND_LABS_CS.CourseProject.BiDirQueueLab4
{
    // A bi-directional priority queue implementation
    public class BiDirectionalPriorityQueue<T>
    {
        private readonly SortedDictionary<int, LinkedList<Entry>> priorities;
        private readonly LinkedList<Entry> insertionOrder;
        private long sequenceCounter;

        private sealed class Entry
        {
            public required T Item;
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

            if (!priorities.TryGetValue(priority, out var list))
            {
                list = new LinkedList<Entry>();
                priorities[priority] = list;
            }

            var priorityNode = list.AddLast(entry);
            entry.PriorityNode = priorityNode;
        }

        // Get the item that was added first without removing it
        public T PeekOldest()
        {
            var node = insertionOrder.First;
            if (node is null) throw new InvalidOperationException("Queue is empty.");
            return node.Value.Item;
        }

        // Get the item that was most recently added without removing it
        public T PeekNewest()
        {
            var node = insertionOrder.Last;
            if (node is null) throw new InvalidOperationException("Queue is empty.");
            return node.Value.Item;
        }

        // Get the item with the highest priority without removing it
        public T PeekHighest()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
            var highestPriority = priorities.Keys.Last();
            var node = priorities[highestPriority].First;
            if (node is null) throw new InvalidOperationException("No items in this priority list.");
            return node.Value.Item;
        }

        // Get the item with the lowest priority without removing it
        public T PeekLowest()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
            var lowestPriority = priorities.Keys.First();
            var node = priorities[lowestPriority].First;
            if (node is null) throw new InvalidOperationException("No items in this priority list.");
            return node.Value.Item;
        }

        // Remove and return the item that was added first
        public T DequeueOldest()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
            var node = insertionOrder.First;
            if (node is null) throw new InvalidOperationException("Queue is empty.");
            var entry = node.Value;

            insertionOrder.Remove(node);
            if (entry.PriorityNode is not null) priorities[entry.Priority].Remove(entry.PriorityNode);
            if (priorities[entry.Priority].Count == 0) priorities.Remove(entry.Priority);

            return entry.Item;
        }

        // Remove and return the item that was most recently added
        public T DequeueNewest()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
            var node = insertionOrder.Last;
            if (node is null) throw new InvalidOperationException("Queue is empty.");
            var entry = node.Value;

            insertionOrder.Remove(node);
            if (entry.PriorityNode is not null) priorities[entry.Priority].Remove(entry.PriorityNode);
            if (priorities[entry.Priority].Count == 0) priorities.Remove(entry.Priority);

            return entry.Item;
        }

        // Remove and return the item with the highest priority
        public T DequeueHighest()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
            var highestPriority = priorities.Keys.Last();
            var node = priorities[highestPriority].First;
            if (node is null) throw new InvalidOperationException("No items in this priority list.");
            var entry = node.Value;

            priorities[highestPriority].Remove(node);
            if (entry.InsertionNode is not null) insertionOrder.Remove(entry.InsertionNode);
            if (priorities[highestPriority].Count == 0) priorities.Remove(highestPriority);

            return entry.Item;
        }

        // Remove and return the item with the lowest priority
        public T DequeueLowest()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
            var lowestPriority = priorities.Keys.First();
            var node = priorities[lowestPriority].First;
            if (node is null) throw new InvalidOperationException("No items in this priority list.");
            var entry = node.Value;

            priorities[lowestPriority].Remove(node);
            if (entry.InsertionNode is not null) insertionOrder.Remove(entry.InsertionNode);
            if (priorities[lowestPriority].Count == 0) priorities.Remove(lowestPriority);

            return entry.Item;
        }

        // Get the total number of items in the queue
        public int Count => insertionOrder.Count;

        // Check if the queue is empty
        public bool IsEmpty => Count == 0;
    }
}