
using System.Net.Http;

namespace PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Core
{
 public interface IAuthStrategy
    {


        void Apply(HttpRequestMessage request);
    }
}
