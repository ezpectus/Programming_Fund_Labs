using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing
{
    // Provides incremental processing of streamed data
    public class DataProcessor
    {
        public async Task ProcessAsync(
            IAsyncEnumerable<DataRecord> records,
            CancellationToken cancellationToken = default)
        {
            int totalCount = 0;

            await foreach (var record in records.WithCancellation(cancellationToken))
            {
                // Initial simple processing logic
                totalCount++;

                // Temporary demo output (can be removed later)
                if (totalCount % 1000 == 0)
                {
                    Console.WriteLine($"Processed {totalCount} records...");
                }
            }

            Console.WriteLine($"Processing completed. Total records: {totalCount}");
        }
    }
}