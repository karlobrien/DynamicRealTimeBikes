using DynamicData;
using DynamicRealTimeBikes.Common;
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

        public RealTimeModel(ISchedulerProvider schProvider)
        {
            _schProvider = schProvider;
            _bikeDataSource = new SourceCache<StationDto, string>(bike => bike.Name);
            _all = _bikeDataSource.AsObservableCache();

            var data = GenerateRealTimeData();
            _cleanup = new CompositeDisposable(_all, _bikeDataSource, data);
        }

        private IDisposable GenerateRealTimeData()
        {
            var station = new StationDto();
            station.Name = "Heuston";
            
            _bikeDataSource.AddOrUpdate(station);

            return new CompositeDisposable();
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
