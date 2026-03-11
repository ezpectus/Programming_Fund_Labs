using System;
using System.Net.Http;
using System.Threading.Tasks;
using PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Auth;
using PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Core;
using PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Service;

namespace PGR_FUND_LABS_CS.CourseProject.ProxyLab8
{
    public class DemoLab8
    {
        public static async Task Run()
        {
            var service = new RealApiService("https://api.example.com");

            Console.WriteLine("=== Lab 8: Authentication Proxy ===\n");

            // ApiKey
            Console.WriteLine("-- ApiKey Auth --");
            var apiKeyProxy = new AuthProxy(service, new ApiKeyAuth("my-secret-key"));
            var request1 = new HttpRequestMessage(HttpMethod.Get, "/data");
            Console.WriteLine(await apiKeyProxy.SendAsync(request1));

            // JWT
            Console.WriteLine("\n-- JWT Auth --");
            var jwtProxy = new AuthProxy(service, new JwtAuth("eyJhbGciOiJIUzI1NiJ9.token"));
            var request2 = new HttpRequestMessage(HttpMethod.Get, "/data");
            Console.WriteLine(await jwtProxy.SendAsync(request2));

            // OAuth
            Console.WriteLine("\n-- OAuth Auth --");
            var oauthProxy = new AuthProxy(service, new OAuthAuth("oauth-access-token-xyz"));
            var request3 = new HttpRequestMessage(HttpMethod.Get, "/data");
            Console.WriteLine(await oauthProxy.SendAsync(request3));
        }
    }
}