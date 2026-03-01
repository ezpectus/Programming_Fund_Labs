using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace PGR_FUND_LABS_CS.CourseProject.LargeDataProcessing
{
    public class DataStreamReader
    {
        // Reads data from a file and yields DataRecord instances incrementally
        public async IAsyncEnumerable<DataRecord> ReadAsync(string filePath)
        {
            using var reader = new StreamReader(filePath);

            string? line;
            int id = 0;

            while ((line = await reader.ReadLineAsync()) != null)
            {
                id++;

                var record = ParseLine(line, id);

                yield return record;
            }
        }

        private DataRecord ParseLine(string line, int id)
        {
            return new DataRecord
            {
                Id = id,
                RawContent = line,
                Value = line.Length // простая логика пока
            };
        }
    }
}