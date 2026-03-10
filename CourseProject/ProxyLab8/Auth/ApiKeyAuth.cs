
using System.Net.Http;
using PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Core;


namespace PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Auth // This class implements the IAuthStrategy interface to provide API key authentication for HTTP requests.
                                                        // It adds the API key to the request headers under the "X-API-Key" header name.
{
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

