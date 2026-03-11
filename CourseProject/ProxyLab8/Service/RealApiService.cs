using System;
using System.Net.Http;
using System.Threading.Tasks;
using PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Core;

namespace PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Service
{
    public class RealApiService : IApiService
    {
        private readonly string _baseUrl;

        public RealApiService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<string> SendAsync(HttpRequestMessage request)
        {
            // Simulate sending the request to the real API and getting a response
            Console.WriteLine($"Sending request to {_baseUrl}{request.RequestUri}");
            await Task.Delay(500); // Simulate network delay
            return $"Response from {_baseUrl}{request.RequestUri}";


        }
    }
}
