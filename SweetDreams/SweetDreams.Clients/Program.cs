using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.Toast;
using SweetDreams.Clients.Helpers;
using SweetDreams.Clients.Services;

namespace SweetDreams.Clients
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            builder.Services.AddBlazoredToast();

            builder.Services.AddScoped(x => {
                var apiUrl = new Uri(builder.Configuration["apiUrl"]);

                return new HttpClient() { BaseAddress = apiUrl };
            });

            var host = builder.Build();

            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.Initialize();

            await host.RunAsync();

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    // Configure your authentication provider options here.
            //    // For more information, see https://aka.ms/blazor-standalone-auth
            //    builder.Configuration.Bind("Local", options.ProviderOptions);
            //});

            //await builder.Build().RunAsync();
        }
    }
}
