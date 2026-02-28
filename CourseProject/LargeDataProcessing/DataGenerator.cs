
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text;


// Responsible for generating large test files
namespace PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing
{
   
        // Generates large test data file for stream processing demo
        public static class DataGenerator
        {
            public static async Task GenerateAsync(string filePath, int recordCount)
            {
                using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

                for (int i = 1; i <= recordCount; i++)
                {
                    await writer.WriteLineAsync($"Record_{i}");
                    if (i % 10000 == 0)  Console.WriteLine($"Generated {i} records...");
                    
                }

                Console.WriteLine("File generation completed.");
            }
        }
    
}