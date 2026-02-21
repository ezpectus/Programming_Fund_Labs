using System;
using System.Collections.Generic;
using System.Linq;

//My leetcode solution for LFU Cache problem

namespace CourseProject.MemoLab3
{
    public class LFUCache
{
    private readonly int capacity;
    private readonly Dictionary<int, LinkedListNode<CacheEntry>> nodes;
    private readonly SortedDictionary<int, LinkedList<CacheEntry>> freqList;

    public LFUCache(int capacity)
    {
        this.capacity = capacity;
        nodes = new Dictionary<int, LinkedListNode<CacheEntry>>(capacity);
            freqList = new SortedDictionary<int, LinkedList<CacheEntry>>();
    }

    public int Get(int key)
    {
        if (!nodes.TryGetValue(key, out var node))
            return -1;

        UpdateFrequency(node);
        return node.Value.Value;
    }

    public void Put(int key, int value)
    {
        if (capacity == 0) return;

        if (nodes.TryGetValue(key, out var node))
        {
            node.Value.Value = value;
            UpdateFrequency(node);
            return;
        }

        if (nodes.Count >= capacity)
            Evict();

        var entry = new CacheEntry(key, value);
        var newNode = new LinkedListNode<CacheEntry>(entry);
        nodes[key] = newNode;

        AddToFrequencyList(newNode, 1);
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
        var lastNode = list.Last;

        list.RemoveLast();
        nodes.Remove(lastNode.Value.Key);

        if (list.Count == 0)
            freqList.Remove(minFreq);
    }

    private class CacheEntry
    {
        public int Key { get; }
        public int Value { get; set; }
        public int Frequency { get; set; }

            public CacheEntry(int key, int value)
        {
            Key = key;
            Value = value;
            Frequency = 1;
          }
       }
    }
  }