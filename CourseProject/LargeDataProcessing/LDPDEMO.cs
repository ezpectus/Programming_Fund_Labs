
using PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing;
using System;
using System.Threading.Tasks;

namespace LargeDataProcessing
{
   class Program
    {
        static async Task Main(string[] args)
        {
            string filePath = "large_data.txt";

            var reader = new DataStreamReader();
            var processor = new DataProcessor();

            // TODO:
            // 1. Generate large file
            // 2. Read file using async stream
            // 3. Process records incrementally

            Console.WriteLine("Lab 6 base structure ready.");
        }
    }
}