//Implement memo function that takes a function and returns a memoized version of that function.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseProject.MemoLab3;

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

                if (cache.TryGet(key, out var cached))
                    return (TResult)cached;

                TResult result = func(arg);
                cache.Set(key, result);
                return result;
            };
        }
    }
}