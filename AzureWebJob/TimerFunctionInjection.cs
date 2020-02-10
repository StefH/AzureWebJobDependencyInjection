using System.IO;
using AzureWebJobDependencyInjection.Services;
using Microsoft.Azure.WebJobs;

namespace AzureWebJobDependencyInjection
{
    public class TimerFunctionInjection
    {
        private readonly ITest _test;

        public TimerFunctionInjection(ITest test)
        {
            _test = test;
        }

        public void ProcessTimerInjected([TimerTrigger("*/35 * * * * *")] TimerInfo myTimer, TextWriter log)
        {
            log.WriteLine(_test.Get());
            log.WriteLine(myTimer.ScheduleStatus);
        }
    }
}