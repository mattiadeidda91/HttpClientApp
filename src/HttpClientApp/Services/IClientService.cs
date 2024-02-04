using HttpClientApp.Models;
using Refit;

namespace HttpClientApp.Services
{
    public interface IClientService
    {
        [Get("/users")]
        Task<ApiResponse<ListResult<User>>> GetUsersAsync(int? page = null, int? delay = null, CancellationToken cancellationToken = default);

        [Get("/users/{id}")]
        Task<ApiResponse<Result<User>>> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);

        [Post("/users")]
        Task<HttpResponseMessage> CreateUsersAsync(CreateUser user, CancellationToken cancellationToken = default);
    }
}