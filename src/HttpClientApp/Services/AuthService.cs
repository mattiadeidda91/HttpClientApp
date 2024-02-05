namespace HttpClientApp.Services
{
    public class AuthService : IAuthService
    {
        public Task<string> GetBearerToken()
        {
            //Example how to use a service for retrive the jwtToken
            return Task.FromResult("123abc");
        }
    }
}
