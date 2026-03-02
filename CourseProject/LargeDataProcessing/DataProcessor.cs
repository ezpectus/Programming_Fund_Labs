using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing
{
    public class DataProcessor
    {
        public static async Task ProcessAsync(IAsyncEnumerable<DataRecord> stream)
        {
            int totalRecords = 0;
            int processedRecords = 0;
            long totalValueSum = 0;

            await foreach (var record in stream)
            {
                totalRecords++;

                if (!ShouldProcess(record))
                    continue;

                processedRecords++;
                totalValueSum += record.Value;

                if (processedRecords % 10000 == 0)
                {
                    Console.WriteLine($"Processed {processedRecords} filtered records...");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Processing statistics:");
            Console.WriteLine($"Total read records: {totalRecords}");
            Console.WriteLine($"Filtered records: {processedRecords}");
            Console.WriteLine($"Sum of filtered values: {totalValueSum}");
        }

        private static bool ShouldProcess(DataRecord record)
        {
            // Simple filtering rule 
            return record.Value > 10;
        }
    }
}
