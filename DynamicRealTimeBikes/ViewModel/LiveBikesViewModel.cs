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

        public LiveBikesViewModel(IRealTimeModel model)
        {
            var filter = new FilterController<StationDto>(t => true);
            var filterApplier = this.WhenValueChanged(t => t.SearchText)
                                    .Throttle(TimeSpan.FromMilliseconds(250))
                                    .Select(BuildFilter)
                                    .Subscribe(filter.Change);

            var connect = model.All
                .Connect()
                .Filter(filter)
                .Transform(t => t)
                .ObserveOnDispatcher()
                .Bind(_data)
                .DisposeMany()
                .Subscribe();
            
            _cleanUp = new CompositeDisposable(connect, filterApplier);
        }

        private Func<StationDto, bool> BuildFilter(string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) return name => true;

            return str => str.Name.Contains(searchText) ||
                        str.Name.Contains(searchText);
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

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetAndRaise(ref _searchText, value);
            }
        }
    }
}
