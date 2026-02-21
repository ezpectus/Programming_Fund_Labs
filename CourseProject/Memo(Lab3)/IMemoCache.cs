//To implement the cache for the memo application, we can define an interface called IMemoCache.
//This interface will provide mthods for adding, retrieving, and removing memos from the cache. Below is an example implementation of the IMemoCache interface in C#:

using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject.MemoLab3
{
    public interface IMemoCache
    {
        void AddMemo(string key, object value);
        object GetMemo(string key);
        void RemoveMemo(string key);
        bool ContainsMemo(string key);
    }
}