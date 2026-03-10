


// LRUCache implementation using LinkedList and Dictionary with DateTime for tracking last access time
// This implementation allows for efficient retrieval and updating of cache items while maintaining the order of access using a linked list.
// The Dictionary provides O(1) access to cache items, while the LinkedList maintains the order of usage for eviction purposes.

/*
 
using System;
using System.Collections.Generic;

public class LRUCache
{

    private readonly int capacity;
    private readonly Dictionary<int, LinkedListNode<CacheItem>> cacheMap;
    private readonly LinkedList<CacheItem> cacheList;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cacheMap = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
        cacheList = new LinkedList<CacheItem>();
    }

    public int Get(int key)
    {
        if (cacheMap.TryGetValue(key, out var node))
        {
            cacheList.Remove(node);
            cacheList.AddFirst(node);
            return node.Value.Value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (cacheMap.TryGetValue(key, out var node))
        {
            node.Value.Value = value;
            cacheList.Remove(node);
            node.Value.LastAcc = DateTime.Now;
            cacheList.AddFirst(node);
        }
        else
        {
            if (cacheMap.Count >= capacity)
            {
                var lastNode = cacheList.Last;
                cacheMap.Remove(lastNode.Value.Key);
                cacheList.RemoveLast();
            }

            var newNode = new LinkedListNode<CacheItem>(new CacheItem(key, value));
            cacheMap.Add(key, newNode);
            cacheList.AddFirst(newNode);
            newNode.Value.LastAcc = DateTime.Now;
        }
    }

    private class CacheItem
    {
        public int Key { get; }
        public int Value { get; set; }
        public DateTime LastAcc
        {
            get; set;
        }
        public CacheItem(int key, int value)
        {
            Key = key;
            Value = value;
            LastAcc = DateTime.Now;
        }
    }
}

*/
