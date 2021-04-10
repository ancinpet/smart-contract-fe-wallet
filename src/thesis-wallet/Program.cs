using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nethereum.UI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Metamask.Blazor;
using Nethereum.Metamask;
using FluentValidation;
using MatBlazor;
using Blazored.LocalStorage;

namespace thesis_wallet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddMatBlazor();
            builder.Services.AddMatToaster(config => {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = false;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 10000;
            });

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IMetamaskInterop, MetamaskBlazorInterop>();
            builder.Services.AddSingleton<MetamaskInterceptor>();
            builder.Services.AddSingleton<MetamaskHostProvider>();
            builder.Services.AddSingleton<IEthereumHostProvider>(serviceProvider =>
            {
                return serviceProvider.GetService<MetamaskHostProvider>();
            });
            builder.Services.AddSingleton<NethereumAuthenticator>();

            await builder.Build().RunAsync();
        }
    }
}
