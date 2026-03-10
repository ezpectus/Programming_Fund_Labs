
using System.Net.Http;
using PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Core;


namespace PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Auth
{
    public class OAuthAuth : IAuthStrategy
    {
        private readonly string _accessToken;
        public OAuthAuth(string accessToken)
        {
            _accessToken = accessToken;
        }

        public void Apply(HttpRequestMessage request)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
        }

    }
}
