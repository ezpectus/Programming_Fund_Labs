using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PGR_FUND_LABS_CS.CourseProject.LoggerLab9.CoreLab9
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);
        bool IsEnabled(LogLevel level);
    }
}
