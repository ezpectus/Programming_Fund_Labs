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
    // Reads large files incrementally using async streams
    public class DataStreamReader
    {
        public async IAsyncEnumerable<DataRecord> ReadAsync(
            string filePath,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            using var stream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 4096,
                useAsync: true);

            using var reader = new StreamReader(stream);
            int id = 0;

            while (!reader.EndOfStream)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var line = await reader.ReadLineAsync();

                if (line is null)
                    continue;

                yield return new DataRecord
                {
                    Id = id++,
                    RawContent = line
                };
            }
        }
    }
}