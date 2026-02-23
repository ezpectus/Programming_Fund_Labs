using System;
using System.Collections.Generic;
using System.Linq;

//My leetcode solution for LFU Cache problem


namespace PGR_FUND_LABS_CS.CourseProject.MemoLab3
{
    public class LFUCache : IMemoCache
    {
        private readonly int capacity;
        private readonly TimeSpan? ttl;

        private readonly Dictionary<string, LinkedListNode<CacheEntry>> nodes;
        private readonly SortedDictionary<int, LinkedList<CacheEntry>> freqList;

        public LFUCache(int capacity, TimeSpan? ttl = null)
        {
            this.capacity = capacity;
            this.ttl = ttl;

            nodes = new Dictionary<string, LinkedListNode<CacheEntry>>();
            freqList = new SortedDictionary<int, LinkedList<CacheEntry>>();
        }

        public bool TryGet(string key, out object value)
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

        public void Set(string key, object value)
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

        public void Remove(string key)
        {
            if (!nodes.TryGetValue(key, out var node))
                return;

            int freq = node.Value.Frequency;

            freqList[freq].Remove(node);
            if (freqList[freq].Count == 0)
                freqList.Remove(freq);

            nodes.Remove(key);
        }

        private void UpdateFrequency(LinkedListNode<CacheEntry> node)
        {
            int oldFreq = node.Value.Frequency;
            freqList[oldFreq].Remove(node);

            if (freqList[oldFreq].Count == 0)
                freqList.Remove(oldFreq);

            node.Value.Frequency++;
            AddToFrequencyList(node, node.Value.Frequency);
        }

        private void AddToFrequencyList(LinkedListNode<CacheEntry> node, int freq)
        {
            if (!freqList.ContainsKey(freq))
                freqList[freq] = new LinkedList<CacheEntry>();

            freqList[freq].AddFirst(node);
        }

        private void Evict()
        {
            int minFreq = freqList.Keys.First();
            var list = freqList[minFreq];
            var nodeToRemove = list.Last;

            list.RemoveLast();
            nodes.Remove(nodeToRemove.Value.Key);

            if (list.Count == 0)
                freqList.Remove(minFreq);
        }

        private class CacheEntry
        {
            public string Key { get; }
            public object Value { get; set; }
            public int Frequency { get; set; }
            public DateTime CreatedAt { get; set; }

            public CacheEntry(string key, object value)
            {
                Key = key;
                Value = value;
                Frequency = 1;
                CreatedAt = DateTime.Now;
            }
        }
    }
}