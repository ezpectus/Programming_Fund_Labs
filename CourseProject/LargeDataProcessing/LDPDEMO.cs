
using PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing;
using System;
using System.Threading.Tasks;

namespace LargeDataProcessing
{
    
        internal class Program
        {
            static async Task Main(string[] args)
            {
                string filePath = "large_data.txt";
                int recordCount = 50000;

                Console.WriteLine("Generating large test file...");
                await DataGenerator.GenerateAsync(filePath, recordCount);

                var reader = new DataStreamReader();
                var processor = new DataProcessor();

                Console.WriteLine("\nStarting incremental processing...");

                var stream = reader.ReadAsync(filePath);

                await processor.ProcessAsync(stream);

                Console.WriteLine("Done.");
            }
      }
}