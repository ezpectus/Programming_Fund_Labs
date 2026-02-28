using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing
{
    // Responsible for reading large files incrementally
    public class DataStreamReader
    {
        // TODO:
        // Implement async iterator using IAsyncEnumerable<DataRecord>
        // Should read file line by line without loading entire file into memory

        public async IAsyncEnumerable<DataRecord> ReadAsync(string filePath)
        {
            // Implementation will be added in next commit
            await Task.CompletedTask;
            yield break;
        }
    }
}