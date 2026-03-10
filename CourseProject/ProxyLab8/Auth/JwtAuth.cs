
using System.Net.Http;
using PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Core;


namespace PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Auth
{
   public class JwtAuth : IAuthStrategy
    {
        private readonly string _jwtToken;
        public JwtAuth(string jwtToken)
        {
            _jwtToken = jwtToken;
        }
        public void Apply(HttpRequestMessage request)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _jwtToken);
        }
    }
}
