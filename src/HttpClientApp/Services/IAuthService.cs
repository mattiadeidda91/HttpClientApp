namespace HttpClientApp.Services
{
    public interface IAuthService
    {
        Task<string> GetBearerToken();
    }
}