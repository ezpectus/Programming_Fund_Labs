//Implement memo function that takes a function and returns a memoized version of that function.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PGR_FUND_LABS_CS.CourseProject.MemoLab3;

namespace PGR_FUND_LABS_CS.CourseProject.MemoLab3
{
    public class Memoizer // This class provides a method to memoize a function using the provided cache.
    {
        private readonly IMemoCache cache;

        public Memoizer(IMemoCache cache) // Constructor that takes an IMemoCache instance to be used for caching results.
        {
            this.cache = cache;
        }

        public Func<T, TResult> Memoize<T, TResult>(Func<T, TResult> func) // Method that takes a function and returns a memoized version of that function.
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