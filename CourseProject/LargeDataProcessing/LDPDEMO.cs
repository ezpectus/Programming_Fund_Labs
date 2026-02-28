
using PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing;
using System;
using System.Threading.Tasks;


namespace PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing
{
    public static class DemoLab6
    {
        public static async Task Run()
        {
            string filePath = "large_data.txt";
            int recordCount = 50000;

            Console.WriteLine("=== Lab 6: Large Data Processing ===");

            Console.WriteLine("Generating large test file...");
            await DataGenerator.GenerateAsync(filePath, recordCount);

            var reader = new DataStreamReader();
            var processor = new DataProcessor();

            Console.WriteLine("\nStarting incremental processing...");

            var stream = reader.ReadAsync(filePath);
            await processor.ProcessAsync(stream);

            Console.WriteLine("Lab 6 completed.");
        }
    }
}