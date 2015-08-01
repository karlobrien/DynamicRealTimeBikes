using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DynamicRealTimeBikes.Infrastructure
{
    public class SchedulerProvider : ISchedulerProvider
    {
        private readonly IScheduler _mainThread;

        public SchedulerProvider(Dispatcher dispatcher)
        {
            _mainThread = new DispatcherScheduler(dispatcher);
        }

        public IScheduler MainThread
        {
            get { return _mainThread; }
        }

        public IScheduler TaskPool
        {
            get { return TaskPoolScheduler.Default; }
        }
    }
}
