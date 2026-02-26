using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace PGR_FUND_LABS_CS.CourseProject.AsyncArray_Lab5_
{
    public static class AsyncMapCallback
    {
        public static void MapAsync<T, TResult>(
            IList<T> source,
            Func<T, Action<TResult>, CancellationToken, Task> selector,
            Action<List<TResult>> onCompleted,
            CancellationToken token)
        {
            var results = new TResult[source.Count];
            int completed = 0;

            for (int i = 0; i < source.Count; i++)
            {
                int index = i;

                Task.Run(async () =>
                {
                    if (token.IsCancellationRequested)
                        return;

                    await selector(source[index], result =>
                    {
                        results[index] = result;

                        if (Interlocked.Increment(ref completed) == source.Count)
                        {
                            onCompleted(new List<TResult>(results));
                        }

                    }, token);

                }, token);
            }
        }
    }
}