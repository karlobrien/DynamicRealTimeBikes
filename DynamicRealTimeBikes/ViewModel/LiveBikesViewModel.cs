using DynamicData.Binding;
using DynamicRealTimeBikes.Common;
using DynamicRealTimeBikes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData;
using DynamicData.Controllers;
using DynamicData.Operators;
using DynamicData.PLinq;

namespace DynamicRealTimeBikes.ViewModel
{
    public class LiveBikesViewModel : AbstractNotifyPropertyChanged, IDisposable
    {
        private readonly IDisposable _cleanUp;
        private IObservableCollection<StationDto> _data = new ObservableCollectionExtended<StationDto>();
        private string _name;

        public LiveBikesViewModel(IRealTimeModel model)
        {
            var connect = model.All
                .Connect()
                .Transform(t => t)
                .ObserveOnDispatcher()
                .Bind(_data)
                .DisposeMany()
                .Subscribe();
            
            _cleanUp = new CompositeDisposable(connect);
        }

        public void Dispose()
        {
            _cleanUp.Dispose();
        }

        public IObservableCollection<StationDto> Data
        {
            get { return _data; }
            set
            {
                SetAndRaise(ref _data, value);
            }
        }

        public string Name
        {
            get { return "Test"; }
        }
    }
}
