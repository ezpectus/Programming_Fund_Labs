
using System;
using System.Collections.Generic;


//My leetcode solution for LRU Cache problem


namespace PGR_FUND_LABS_CS.CourseProject.MemoLab3
{
    public class LRUCache : IMemoCache
    {
        private readonly int capacity;
        private readonly TimeSpan? ttl;

        private readonly Dictionary<string, LinkedListNode<CacheItem>> map;
        private readonly LinkedList<CacheItem> list;

        public LRUCache(int capacity, TimeSpan? ttl = null)
        {
            this.capacity = capacity;
            this.ttl = ttl;

            map = new Dictionary<string, LinkedListNode<CacheItem>>();
            list = new LinkedList<CacheItem>();
        }

        public bool TryGet(string key, out object value)
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

        public void Set(string key, object value)
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

        public void Remove(string key)
        {
            if (!map.TryGetValue(key, out var node))
                return;

            list.Remove(node);
            map.Remove(key);
        }

        private class CacheItem
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