//To implement the cache for the memo application, we can define an interface called IMemoCache.
//This interface will provide mthods for adding, retrieving, and removing memos from the cache. Below is an example implementation of the IMemoCache interface in C#:

using System;
using System.Collections.Generic;
using System.Linq;

namespace PGR_FUND_LABS_CS.CourseProject.MemoLab3
{
    public interface IMemoCache // This interface defines the contract for a memo cache, which includes methods for retrieving, adding, and removing items from the cache.
    {
        bool TryGet(string key, out object value); // Method to attempt to retrieve a value from the cache based on the provided key. It returns true if the key exists and is valid, otherwise false. The retrieved value is output through the 'value' parameter.
        void Set(string key, object value); // Method to add or update a value in the cache with the specified key. If the key already exists, it updates the value; otherwise, it adds a new entry to the cache.
        void Remove(string key); // Method to remove an entry from the cache based on the provided key. If the key exists, it removes the corresponding entry from the cache.
    }
}