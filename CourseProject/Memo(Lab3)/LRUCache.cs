
using System;
using System.Collections.Generic;


//My leetcode solution for LRU Cache problem


namespace PGR_FUND_LABS_CS.CourseProject.MemoLab3
{
    //LRU Cache implementation with optional TTL (Time To Live) for cache entries.
    public class LRUCache : IMemoCache 
    {
        private readonly int capacity;
        private readonly TimeSpan? ttl;

        private readonly Dictionary<string, LinkedListNode<CacheItem>> map;
        private readonly LinkedList<CacheItem> list;

        public LRUCache(int capacity, TimeSpan? ttl = null) // Constructor that initializes the LRUCache with a specified capacity and an optional TTL for cache entries.
        {
            this.capacity = capacity;
            this.ttl = ttl;

            map = new Dictionary<string, LinkedListNode<CacheItem>>();
            list = new LinkedList<CacheItem>();
        }

        public bool TryGet(string key, out object value) // Method to retrieve a value from the cache based on the provided key. It returns true if the key exists and is valid (not expired), otherwise false.
        {
            if (!map.TryGetValue(key, out var node))
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

            list.Remove(node);
            list.AddFirst(node);

            value = node.Value.Value;
            return true;
        }

        public void Set(string key, object value) // Method to add or update a value in the cache with the specified key. If the cache exceeds its capacity, it evicts the least recently used item.
        {
            if (capacity == 0)
                return;

            if (map.TryGetValue(key, out var node))
            {
                node.Value.Value = value;
                node.Value.CreatedAt = DateTime.Now;
                list.Remove(node);
                list.AddFirst(node);
                return;
            }

            if (map.Count >= capacity)
            {
                var last = list.Last;
                map.Remove(last.Value.Key);
                list.RemoveLast();
            }

            var item = new CacheItem(key, value);
            var newNode = new LinkedListNode<CacheItem>(item);

            map[key] = newNode;
            list.AddFirst(newNode);
        }

        public void Remove(string key) // Method to remove a specific key and its associated value from the cache.
        {
            if (!map.TryGetValue(key, out var node))
                return;

            list.Remove(node);
            map.Remove(key);
        }

        private class CacheItem // Private class representing an individual cache entry, containing the key, value, and the timestamp of when it was created (used for TTL management).
        {
            public string Key { get; }
            public object Value { get; set; }
            public DateTime CreatedAt { get; set; }

            public CacheItem(string key, object value)
            {
                Key = key;
                Value = value;
                CreatedAt = DateTime.Now;
            }
        }
    }
}