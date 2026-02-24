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

    }
}