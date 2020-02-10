using System;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;

namespace AzureWebJobDependencyInjection
{
    public class ServiceProviderJobActivator : IJobActivator
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceProviderJobActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T CreateInstance<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}