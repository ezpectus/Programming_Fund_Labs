using System.Net.Http;
using PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Core;

namespace PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Auth
{
    // Injects API key into request headers under "X-API-Key"
    public class ApiKeyAuth : IAuthStrategy
    {
        private readonly string _apiKey;

        public ApiKeyAuth(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void Apply(HttpRequestMessage request)
        {
            request.Headers.Add("X-API-Key", _apiKey);
        }
    }
}