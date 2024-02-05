using HttpClientApp.Services;
using Microsoft.Extensions.Logging;

namespace HttpClientApp.Handler
{
    public class CustomHttpClientHandler : HttpClientHandler
    {
        private readonly ILogger<CustomHttpClientHandler> logger;
        private readonly IAuthService authService;

        public CustomHttpClientHandler(IAuthService authService, ILogger<CustomHttpClientHandler> logger) 
        { 
            this.authService = authService;
            this.logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Example of custom HttpClientHandler to set and use specific request configurations like Authorization Header or anything else

            logger.LogDebug("Retrieving the Bearer Token and setting the request headers");

            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await authService.GetBearerToken());
            request.Headers.Add("CustomHeader1", "Value1");

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
