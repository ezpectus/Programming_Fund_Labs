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
          public async Task ProcessAsync(IAsyncEnumerable<DataRecord> stream)
           {
                int totalRecords = 0;
                long totalValSum = 0;

                await foreach (var record in stream)
                {
                    totalRecords++;
                    totalValSum += record.Value;

                    // Simple processing example:
                    // Here we just simulate lightweight work
             
                    if (totalRecords % 10000 == 0) Console.WriteLine($"Processed {totalRecords} records...");
                    
                }

                Console.WriteLine();
                Console.WriteLine("Processing statistics:");
                Console.WriteLine($"Total records: {totalRecords}");
                Console.WriteLine($"Total value sum:  {totalValSum}");
            }
       }
  }
