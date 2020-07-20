using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ReactiveUI;
using Splat.Microsoft.Extensions.DependencyInjection;
using Splat;
using BasicCRUDTool3.Windows.ViewModels;
using BasicCRUDTool3.Blazor.Client.Pages;

namespace BasicCRUDTool3.Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services
                .AddBlazorise(options =>
               {
                   options.ChangeTextOnKeyPress = false;
               })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            builder.Services.UseMicrosoftDependencyResolver(); //Splat config
            var resolver = Locator.CurrentMutable;
            resolver.InitializeSplat();
            resolver.InitializeReactiveUI();

            Locator.CurrentMutable.Register(() => new AlbumsComponent(), typeof(IViewFor<AlbumsViewModel>)); //Splat
            Locator.CurrentMutable.Register(() => new AlbumComponent(), typeof(IViewFor<AlbumViewModel>)); //Splat
            builder.Services.AddScoped<AlbumsComponent>();


            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var host = builder.Build();

            host.Services.UseBootstrapProviders()
                .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}
