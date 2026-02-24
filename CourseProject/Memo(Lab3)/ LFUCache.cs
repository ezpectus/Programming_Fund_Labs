using System;
using System.Collections.Generic;
using System.Linq;

//My leetcode solution for LFU Cache problem


namespace PGR_FUND_LABS_CS.CourseProject.MemoLab3
{
    public class LFUCache : IMemoCache // Implementing a simple LFU Cache with optional TTL
    {
        private readonly int capacity;
        private readonly TimeSpan? ttl;

        private readonly Dictionary<string, LinkedListNode<CacheEntry>> nodes;
        private readonly SortedDictionary<int, LinkedList<CacheEntry>> freqList;

        public LFUCache(int capacity, TimeSpan? ttl = null) // Constructor to initialize the cache with capacity and optional TTL
        {
            this.capacity = capacity;
            this.ttl = ttl;

            nodes = new Dictionary<string, LinkedListNode<CacheEntry>>();
            freqList = new SortedDictionary<int, LinkedList<CacheEntry>>();
        }

        public bool TryGet(string key, out object value) // Method to retrieve a value from the cache, checking for TTL and updating frequency
        {
            if (!nodes.TryGetValue(key, out var node))
            {
                value = null;
                return false;
            }

            // TTL check
            if (ttl.HasValue && DateTime.Now - node.Value.CreatedAt > ttl.Value)
            {
                Remove(key);
                value = null;
                return false;
            }

            UpdateFrequency(node);
            value = node.Value.Value;
            return true;
        }

        public void Set(string key, object value) // Method to add or update a value in the cache, evicting if necessary
        {
            if (capacity == 0)
                return;

            if (nodes.TryGetValue(key, out var existingNode))
            {
                existingNode.Value.Value = value;
                existingNode.Value.CreatedAt = DateTime.Now;
                UpdateFrequency(existingNode);
                return;
            }

            if (nodes.Count >= capacity)
                Evict();

            var entry = new CacheEntry(key, value);
            var newNode = new LinkedListNode<CacheEntry>(entry);

            nodes[key] = newNode;
            AddToFrequencyList(newNode, 1);
        }

        public void Remove(string key) // Method to remove a value from the cache
        {
            if (!nodes.TryGetValue(key, out var node))
                return;

            int freq = node.Value.Frequency;

            freqList[freq].Remove(node);
            if (freqList[freq].Count == 0)
                freqList.Remove(freq);

            nodes.Remove(key);
        }

        private void UpdateFrequency(LinkedListNode<CacheEntry> node) // Method to update the frequency of a cache entry and move it to the appropriate frequency list
        {
            int oldFreq = node.Value.Frequency;
            freqList[oldFreq].Remove(node);

            if (freqList[oldFreq].Count == 0)
                freqList.Remove(oldFreq);

            node.Value.Frequency++;
            AddToFrequencyList(node, node.Value.Frequency);
        }

        private void AddToFrequencyList(LinkedListNode<CacheEntry> node, int freq) // Method to add a cache entry to the frequency list based on its frequency
        {
            if (!freqList.ContainsKey(freq))
                freqList[freq] = new LinkedList<CacheEntry>();

            freqList[freq].AddFirst(node);
        }

        private void Evict() // Method to evict the least frequently used cache entry when capacity is exceeded
        {
            int minFreq = freqList.Keys.First();
            var list = freqList[minFreq];
            var nodeToRemove = list.Last;

            list.RemoveLast();
            nodes.Remove(nodeToRemove.Value.Key);

            if (list.Count == 0)
                freqList.Remove(minFreq);
        }

        private class CacheEntry // Internal class to represent a cache entry, storing the key, value, frequency, and creation time for TTL management
        {
            public string Key { get; }
            public object Value { get; set; }
            public int Frequency { get; set; }
            public DateTime CreatedAt { get; set; }

            public CacheEntry(string key, object value) // Constructor to initialize a cache entry with the key, value, initial frequency, and creation time
            {
                Key = key;
                Value = value;
                Frequency = 1;
                CreatedAt = DateTime.Now;
            }
        }
    }
}