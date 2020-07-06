using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RobotGame.Shared;

namespace RobotGame
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            builder.RootComponents.Add<App>("app");

            builder
                .Services
                .AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);

            builder.Services.AddSingleton<Game>();

            await builder.Build().RunAsync();
        }


    }
}
