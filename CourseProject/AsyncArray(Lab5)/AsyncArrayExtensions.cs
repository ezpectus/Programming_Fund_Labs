using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace PGR_FUND_LABS_CS.CourseProject.AsyncArray_Lab5_
{
    public static class AsyncMap
    {
        // Promise-style (Task-based)
        public static async Task<List<TResult>> MapAsync<T, TResult>(
            IEnumerable<T> source,
            Func<T, Task<TResult>> selector)
        {
            var tasks = source.Select(selector);
            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }

        // Promise-style with Cancellation
        public static async Task<List<TResult>> MapAsync<T, TResult>(
            IEnumerable<T> source,
            Func<T, CancellationToken, Task<TResult>> selector,
            CancellationToken token)
        {
            var tasks = source.Select(item =>
            {
                token.ThrowIfCancellationRequested();
                return selector(item, token);
            });

            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }
    }
}