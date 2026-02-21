//Implement memo function that takes a function and returns a memoized version of that function.

using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject.MemoLab3
{
    public class Memoizer
    {
        private readonly IMemoCache cache;
        public Memoizer(IMemoCache cache)
        {
            this.cache = cache;
        }
        public Func<T, TResult> Memoize<T, TResult>(Func<T, TResult> func)
        {
            return arg =>
            {
                string key = $"{func.Method.Name}:{arg}";
                if (cache.ContainsMemo(key))
                {
                    return (TResult)cache.GetMemo(key);
                }
                else
                {
                    TResult result = func(arg);
                    cache.AddMemo(key, result);
                    return result;
                }
            };
        }
    }
}