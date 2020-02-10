namespace AzureWebJobDependencyInjection.Services
{
    internal class Test : ITest
    {
        public string Get()
        {
            return "42";
        }
    }
}