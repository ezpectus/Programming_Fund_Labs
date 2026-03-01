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
            public async Task ProcessAsync(IAsyncEnumerable<string> stream)
            {
                int totalLines = 0;
                long totalCharacters = 0;

                await foreach (var line in stream)
                {
                    totalLines++;
                    totalCharacters += line.Length;

                    // Simple processing example:
                    // Here we just simulate lightweight work
                    var processed = line.ToUpper();

                    if (totalLines % 10000 == 0) Console.WriteLine($"Processed {totalLines} lines...");
                    
                }

                Console.WriteLine();
                Console.WriteLine("Processing statistics:");
                Console.WriteLine($"Total lines: {totalLines}");
                Console.WriteLine($"Total characters: {totalCharacters}");
            }
       }
  }
