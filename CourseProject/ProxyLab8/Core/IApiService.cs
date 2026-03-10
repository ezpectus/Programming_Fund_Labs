using PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Core;
using System.Net.Http;
using System.Threading.Tasks;

namespace PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Core
{
public interface IApiService
    {
        Task<string> SendAsync(HttpRequestMessage request);
    }
}
