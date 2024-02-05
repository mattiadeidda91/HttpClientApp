using HttpClientLib.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly.Extensions.Http;
using Polly;
using Refit;
using Polly.Timeout;

namespace HttpClientLib.Extensions
{
    public static class HttpClientFactory
    {
        /// <summary>
        /// Create and configure a Refit HttpClient with Polly
        /// </summary>
        /// <typeparam name="TInterface">Refit interface to create a Typed Client</typeparam>
        /// <param name="services"></param>
        /// <param name="configuration">IConfiguration</param>
        /// <param name="refitSettings">RefitSettings</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddHttpClientPollyRefit<TInterface>(this IServiceCollection services, 
            IConfiguration configuration, 
            RefitSettings? refitSettings = null)
                where TInterface : class
        {
            var options = configuration.GetRequiredSection(nameof(HttpRefitPollyOptions)).Get<HttpRefitPollyOptions>();

            ArgumentNullException.ThrowIfNull(options);
            ArgumentNullException.ThrowIfNull(options.HttpClientOptions);

            var httpClient = services.AddHttpClient(options.HttpClientOptions.Name ?? string.Empty, client =>
            {
                client.BaseAddress = options.HttpClientOptions.BaseAddress != null ? new Uri(options.HttpClientOptions.BaseAddress) : null;
                if (options.HttpClientOptions.Timeout > 0)
                    client.Timeout = TimeSpan.FromSeconds(options.HttpClientOptions.Timeout);
            })
            .AddTypedClient(c => RestService.For<TInterface>(c, refitSettings));

            if (options.PollyOptions?.RetryPolicyEnable ?? false)
            {
                _ = httpClient.SetDefaultPollyPolicy(options);
            }

            return services;
        }

        /// <summary>
        /// Create and configure a Refit HttpClient with Polly
        /// </summary>
        /// <typeparam name="TInterface">Refit interface to create a Typed Client</typeparam>
        /// <typeparam name="THandler">HttpClientHandler</typeparam>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        /// <param name="refitSettings">RefitSettings</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddHttpClientPollyRefit<TInterface, THandler>(this IServiceCollection services,
            IConfiguration configuration,
            RefitSettings? refitSettings = null)
                where TInterface : class
                where THandler : HttpClientHandler
        {
            var options = configuration.GetRequiredSection(nameof(HttpRefitPollyOptions)).Get<HttpRefitPollyOptions>();

            ArgumentNullException.ThrowIfNull(options);
            ArgumentNullException.ThrowIfNull(options.HttpClientOptions);

            var httpClient = services.AddHttpClient(options.HttpClientOptions.Name ?? string.Empty, client =>
            {
                client.BaseAddress = options.HttpClientOptions.BaseAddress != null ? new Uri(options.HttpClientOptions.BaseAddress) : null;
                if (options.HttpClientOptions.Timeout > 0)
                    client.Timeout = TimeSpan.FromSeconds(options.HttpClientOptions.Timeout);
            })
            .AddTypedClient(c => RestService.For<TInterface>(c, refitSettings))
            .ConfigurePrimaryHttpMessageHandler<THandler>();

            if (options.PollyOptions?.RetryPolicyEnable ?? false)
            {
                _ = httpClient.SetDefaultPollyPolicy(options);
            }

            return services;
        }

        /// <summary>
        /// Create and configure a Refit HttpClient with Polly
        /// </summary>
        /// <typeparam name="TInterface">Refit interface to create a Typed Client</typeparam>
        /// <param name="services"></param>
        /// <param name="configuration">IConfiguration</param>
        /// <param name="pollyPolicy">Polly policy, if null use the default policy</param>
        /// <param name="refitSettings">RefitSettings</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddHttpClientPollyRefit<TInterface>(this IServiceCollection services, 
            IConfiguration configuration,
            IAsyncPolicy<HttpResponseMessage>? pollyPolicy = null,
            RefitSettings? refitSettings = null) 
                where TInterface : class
        {
            var options = configuration.GetRequiredSection(nameof(HttpRefitPollyOptions)).Get<HttpRefitPollyOptions>();

            ArgumentNullException.ThrowIfNull(options);
            ArgumentNullException.ThrowIfNull(options.HttpClientOptions);

            var httpClient = services.AddHttpClient(options.HttpClientOptions.Name ?? string.Empty, client =>
            {
                client.BaseAddress = options.HttpClientOptions.BaseAddress != null ? new Uri(options.HttpClientOptions.BaseAddress) : null;
                if (options.HttpClientOptions.Timeout > 0)
                    client.Timeout = TimeSpan.FromSeconds(options.HttpClientOptions.Timeout);
            })
            .AddTypedClient(c => RestService.For<TInterface>(c, refitSettings)); //Refit client

            //Polly configuration
            if (options.PollyOptions?.RetryPolicyEnable ?? false)
            {
                ArgumentNullException.ThrowIfNull(options.PollyOptions);

                if (pollyPolicy != null)
                    httpClient.AddPolicyHandler(pollyPolicy);  //Consumer polly policy
                else   
                    httpClient.SetDefaultPollyPolicy(options); //Libary polly default policy
            }

            return services;
        }

        /// <summary>
        /// Create and configure a Refit HttpClient with Polly
        /// </summary>
        /// <typeparam name="TInterface">Refit interface to create a Typed Client</typeparam>
        /// <typeparam name="THandler">HttpClientHandler</typeparam>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        /// <param name="pollyPolicy">Polly policy, if null use the default policy</param>
        /// <param name="refitSettings">RefitSettings</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddHttpClientPollyRefit<TInterface, THandler>(this IServiceCollection services,
            IConfiguration configuration,
            IAsyncPolicy<HttpResponseMessage>? pollyPolicy = null,
            RefitSettings? refitSettings = null)
                where TInterface : class
                where THandler : HttpClientHandler
        {
            var options = configuration.GetRequiredSection(nameof(HttpRefitPollyOptions)).Get<HttpRefitPollyOptions>();

            ArgumentNullException.ThrowIfNull(options);
            ArgumentNullException.ThrowIfNull(options.HttpClientOptions);

            var httpClient = services.AddHttpClient(options.HttpClientOptions.Name ?? string.Empty, client =>
            {
                client.BaseAddress = options.HttpClientOptions.BaseAddress != null ? new Uri(options.HttpClientOptions.BaseAddress) : null;
                if (options.HttpClientOptions.Timeout > 0)
                    client.Timeout = TimeSpan.FromSeconds(options.HttpClientOptions.Timeout);
            })
            .AddTypedClient(c => RestService.For<TInterface>(c, refitSettings)) //Refit client
            .ConfigurePrimaryHttpMessageHandler<THandler>(); //HttpClientHandler

            //Polly configuration
            if (options.PollyOptions?.RetryPolicyEnable ?? false)
            {
                ArgumentNullException.ThrowIfNull(options.PollyOptions);

                if (pollyPolicy != null)
                    httpClient.AddPolicyHandler(pollyPolicy);  //Consumer polly policy
                else
                    httpClient.SetDefaultPollyPolicy(options); //Libary polly default policy
            }

            return services;
        }

        /// <summary>
        /// Set default library polly policy
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private static IHttpClientBuilder SetDefaultPollyPolicy(this IHttpClientBuilder httpClient, HttpRefitPollyOptions options)
        {
            var isOnlyGetMethod = options.PollyOptions?.Configuration?.isOnlyGetMethod ?? false;

            //LifeTime
            if (options.PollyOptions?.Configuration?.HandlerLifeTime > 0)
                httpClient = httpClient.SetHandlerLifetime(TimeSpan.FromMinutes(options.PollyOptions.Configuration.HandlerLifeTime));

            //Only GET
            if (isOnlyGetMethod)
                httpClient.AddPolicyHandler(request => request.Method == HttpMethod.Get ? GetRetryPolicy(options.PollyOptions) : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>()); //Only for HttpMethod GET
            else 
                httpClient.AddPolicyHandler(GetRetryPolicy(options.PollyOptions)); //For all HttpMethods

            //Timeout Policy
            if (options.HttpClientOptions!.Timeout > 0)
                httpClient.AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(options.HttpClientOptions.Timeout)));

            return httpClient;
        }

        /// <summary>
        /// Polly retry policy
        /// </summary>
        /// <param name="options"></param>
        /// <param name="isOnlyGetMethod"></param>
        /// <returns></returns>
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(PollyOptions? options)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError() // Network failures (System.Net.Http.HttpRequestException), HTTP 5XX status codes (server errors), HTTP 408 status code (request timeout)
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .Or<TimeoutRejectedException>() // thrown by Polly's TimeoutPolicy if the inner call times out
                .WaitAndRetryAsync(options?.Configuration?.MaxRetry ?? 3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(options?.Configuration?.RetryDelay ?? 2, retryAttempt)));
        }


        #region Ideas

        /// <summary>
        /// Create HttpClient
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        //public static IServiceCollection AddHttpClientPollyRefit2(this IServiceCollection services, IConfiguration configuration)
        //{
        //    /* NOT WORKING BEACAUSE NOT USE REFIT and IClientService cannot be resolve in MainForm dependency injection */
        //    var options = configuration.GetRequiredSection(nameof(HttpRefitPollyOptions)).Get<HttpRefitPollyOptions>();

        //    ArgumentNullException.ThrowIfNull(options);
        //    ArgumentNullException.ThrowIfNull(options.HttpClientOptions);

        //    services.AddHttpClient(options.HttpClientOptions.Name ?? string.Empty, client =>
        //    {
        //        client.BaseAddress = options.HttpClientOptions.BaseAddress != null ? new Uri(options.HttpClientOptions.BaseAddress) : null;
        //        if (options.HttpClientOptions.Timeout > 0)
        //            client.Timeout = TimeSpan.FromMilliseconds(options.HttpClientOptions.Timeout);
        //    })
        //    .SetHandlerLifetime(TimeSpan.FromMinutes(options.PollyOptions.Configuration.HandlerLifeTime))
        //    .AddPolicyHandler(GetRetryPolicy(options.PollyOptions));

        //    return services;
        //}


        //Refit HttpClient
        //var httpRefit = services.AddRefitClient<TInterface>(null, options.HttpClientOptions.Name ?? string.Empty)
        //    .ConfigureHttpClient(client => 
        //{
        //    client.BaseAddress = options.HttpClientOptions.BaseAddress != null ? new Uri(options.HttpClientOptions.BaseAddress) : null;
        //    if (options.HttpClientOptions.Timeout > 0)
        //        client.Timeout = TimeSpan.FromMilliseconds(options.HttpClientOptions.Timeout);
        //});

        #endregion
    }
}
