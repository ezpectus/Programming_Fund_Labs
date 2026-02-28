using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing
{
    // Responsible for processing incoming data records
    public class DataProcessor
    {
        // TODO:
        // Implement incremental processing logic
        // Example: counting, filtering, transformation

        public async Task ProcessAsync(IAsyncEnumerable<DataRecord> records)
        {
            await Task.CompletedTask;
        }
    }
}