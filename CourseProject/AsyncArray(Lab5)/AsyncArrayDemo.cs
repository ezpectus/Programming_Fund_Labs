using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;




namespace PGR_FUND_LABS_CS.CourseProject.AsyncArray_Lab5_
{
    public static class AsyncArrayDemo
    {
        public static async Task Run()
        {
            var numbers = Enumerable.Range(1, 5).ToList();

            Console.WriteLine("=== Promise-based Map ===");

            var squared = await AsyncMap.MapAsync(numbers, async n =>
            {
                await Task.Delay(500);
                return n * n;
            });

            Console.WriteLine("Result: " + string.Join(", ", squared));


            Console.WriteLine("\n=== Promise-based Map with Cancellation ===");

            using var cts = new CancellationTokenSource();
            cts.CancelAfter(1000);

            try
            {
                var resultWithCancel = await AsyncMap.MapAsync(
                    numbers,
                    async (n, token) =>
                    {
                        await Task.Delay(700, token);
                        return n * 10;
                    },
                    cts.Token);

                Console.WriteLine("Result: " + string.Join(", ", resultWithCancel));
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was cancelled.");
            }


            Console.WriteLine("\n=== Callback-based Map ===");

            var completionSource = new TaskCompletionSource<bool>();

            AsyncMapCallback.MapAsync(
                numbers,
                async (n, callback, token) =>
                {
                    await Task.Delay(400, token);
                    callback(n + 100);
                },
                results =>
                {
                    Console.WriteLine("Callback result: " + string.Join(", ", results));
                    completionSource.SetResult(true);
                },
                CancellationToken.None);

            await completionSource.Task;
        }
    }
}