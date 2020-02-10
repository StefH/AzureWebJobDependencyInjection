using System;
using AzureWebJobDependencyInjection.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;

namespace AzureWebJobDependencyInjection
{
    /// <summary>
    /// ... Make sure to start Azure Storage Emulator
    /// </summary>
    class Program
    {
        static void Main()
        {
            var config = new JobHostConfiguration
            {
                DashboardConnectionString = null // https://github.com/Azure/azure-functions-host/issues/1799
            };

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();

                // https://github.com/Azure/azure-webjobs-sdk-extensions/issues/31
                config.HostId = (Environment.MachineName.ToLowerInvariant() + "stef" + Guid.NewGuid()).Substring(0, 32);
            }

            config.UseTimers();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<ITest, Test>();
            serviceCollection.AddScoped<TimerFunctionInjection>();

            config.JobActivator = new ServiceProviderJobActivator(serviceCollection.BuildServiceProvider());

            var host = new JobHost(config);
            
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    }
}