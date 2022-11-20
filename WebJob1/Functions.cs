using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace WebJob48;

public class QueueFunction
{
    private readonly ILogger<QueueFunction> _logger;

    public QueueFunction(ILogger<QueueFunction> logger)
    {
        _logger = logger;
    }


    public Task ProcessQueueMessageAsync([QueueTrigger("abc")] string message, TextWriter log)
    {
        log.WriteLine(message);
        _logger.LogCritical("hello : " + message);

        return Task.CompletedTask;
    }
}