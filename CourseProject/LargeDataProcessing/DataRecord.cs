using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing
{
    // Represents a single data record from the large dataset
    public class DataRecord
    {
        public long Value  { get; set; }
        public int Id { get; set; }
        public string RawContent { get; set; } = string.Empty;

        // TODO:
        // Add parsing logic if structured data format is required
    }
}