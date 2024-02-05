using HttpClientApp.Handler;
using HttpClientApp.Services;
using HttpClientLib.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

namespace HttpClientApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //To use appSettings.json set in Property file the "Copy to Output Directory" = "Copy Always"

            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build();

            var services = host.Services;
            var mainForm = services.GetService<MainForm>();

            Application.Run(mainForm);
        }

        private static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            //Not necessary bacuase it's the refit default, but use this settings if you need Newtonsoft.Json and not SystemTextJson
            var refitSetting = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive= true,
                    PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
                })
            };

            services.AddTransient<CustomHttpClientHandler>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddSingleton<MainForm>();

            services.AddHttpClientPollyRefit<IClientService, CustomHttpClientHandler>(hostContext.Configuration, refitSetting);
        }
    }
}