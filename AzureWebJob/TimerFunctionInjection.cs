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

        public void ProcessTimerInjected([TimerTrigger("%CronTimerFunctionInjection%")] TimerInfo myTimer, TextWriter log)
        {
            log.WriteLine(_test.Get());
            log.WriteLine(myTimer.ScheduleStatus);
        }
    }
}