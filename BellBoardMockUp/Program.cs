using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BellBoardMockUp.Models;
using BellBoardMockUp.Utilities;

namespace BellBoardMockUp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<Performance>();

            builder.Services.AddHttpClient<TJBarnesService>(client =>
            {
                client.BaseAddress = new Uri("https://tjbarnes.com/");
            });

            builder.Services.AddHttpClient<CompLibService>(client =>
            {
                client.BaseAddress = new Uri("https://api.complib.org/");
            });

            await builder.Build().RunAsync();
        }
    }
}
