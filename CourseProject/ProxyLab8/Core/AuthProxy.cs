using System.Net.Http;
using System.Threading.Tasks;



namespace PGR_FUND_LABS_CS.CourseProject.ProxyLab8.Core
{
     public class AuthProxy : IApiService
    {
        private readonly IApiService _apiService;
        private readonly IAuthStrategy _authStrategy;

        public AuthProxy(IApiService apiService, IAuthStrategy authStrategy)
        {
            _apiService = apiService;
            _authStrategy = authStrategy;
        }
      
        public async Task<string> SendAsync(HttpRequestMessage request)
        {
             _authStrategy.Apply(request);
           return await _apiService.SendAsync(request);
        }


    }
}
