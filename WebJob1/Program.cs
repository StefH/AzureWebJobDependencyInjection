using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebJob48;

internal class Program
{
    static async Task Main()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "local";

        var builder = new HostBuilder();

        builder.ConfigureAppConfiguration(cb =>
        {
            cb.AddJsonFile("appsettings.json");
            cb.AddJsonFile($"appsettings.{environment}.json", true, true);
        });

        builder.ConfigureLogging((hostBuilderContext, loggingBuilder) =>
        {
            loggingBuilder.AddConfiguration(hostBuilderContext.Configuration.GetSection("Logging"));
            loggingBuilder.AddConsole();
        });

        builder.ConfigureWebJobs(b =>
        {
            b.AddAzureStorageCoreServices();
            b.AddAzureStorageBlobs();
            b.AddAzureStorageQueues();
        });
        
        var host = builder.Build();
        using (host)
        {
            await host.RunAsync();
        }
    }
}