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
        public static Task<List<TResult>> MapAsync<T, TResult>(
            IEnumerable<T> source,
            Func<T, Task<TResult>> selector)
        {
            return Task.WhenAll(source.Select(selector))
                       .ContinueWith(t => t.Result.ToList());
        }

        // With cancellation
       //ToDO  with CancellationToken
    }
}