using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRealTimeBikes.Infrastructure
{
    public static class InternalExtensions
    {
        public static IDisposable ScheduleRecurringAction(
                            this IScheduler scheduler,
                            TimeSpan interval,
                            Action action)
        {
            return scheduler.Schedule(
                interval, scheduleNext =>
                {
                    action();
                    scheduleNext(interval);
                });
        }
    }
}
