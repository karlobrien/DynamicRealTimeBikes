using DynamicData;
using DynamicRealTimeBikes.Common;
using DynamicRealTimeBikes.Common.Service;
using DynamicRealTimeBikes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRealTimeBikes.Model
{
    public class RealTimeModel : IRealTimeModel, IDisposable
    {
        private readonly ISourceCache<StationDto, string> _bikeDataSource;
        private readonly IDisposable _cleanup;
        private readonly ISchedulerProvider _schProvider;
        private readonly IBikeService _bikeService;

        public RealTimeModel(ISchedulerProvider schProvider, IBikeService bikeService)
        {
            _schProvider = schProvider;
            _bikeService = bikeService;
            _bikeDataSource = new SourceCache<StationDto, string>(bike => bike.Name);
            _all = _bikeDataSource.AsObservableCache();

            var data = GenerateRealTimeData();
            _cleanup = new CompositeDisposable(_all, _bikeDataSource, data);
        }

        private async Task<IDisposable> GenerateRealTimeData()
        {
            TimeSpan interval = TimeSpan.FromSeconds(10);           
            _bikeDataSource.AddOrUpdate(await _bikeService.GetAllStationData());

            var bikeRequester = _schProvider.TaskPool.ScheduleRecurringAction(interval, async () =>
                {
                    var stationData = await _bikeService.GetAllStationData();
                    _bikeDataSource.AddOrUpdate(stationData);
                });

            return new CompositeDisposable(bikeRequester);
        }

        private IObservableCache<StationDto, string> _all;
        public IObservableCache<StationDto, string> All
        {
            get { return _all; }
        }


        public void Dispose()
        {
            _cleanup.Dispose();
        }
    }
}
