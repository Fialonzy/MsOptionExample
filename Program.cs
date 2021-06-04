using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MsOptionExample.Options;
using MsOptionExample.Services;

namespace MsOptionExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddJsonFile("locations.json",false,true);
                    configHost.AddCommandLine(args);
                })
                .ConfigureServices((ctx, services) => {
                    services.AddOptions();
                    services.Configure<LocationOptions>(ctx.Configuration);
                    services.AddScoped<WetherService>();
                    services.AddHostedService<MainHostedService>();
                });
    }
}
