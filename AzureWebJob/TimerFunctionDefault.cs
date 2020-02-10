using System.IO;
using Microsoft.Azure.WebJobs;

namespace AzureWebJobDependencyInjection
{
    public class TimerFunctionDefault
    {
        public static void ProcessTimerNormal([TimerTrigger("%CronTimerFunctionDefault%")] TimerInfo myTimer, TextWriter log)
        {
            log.WriteLine(myTimer.ScheduleStatus);
        }
    }
}