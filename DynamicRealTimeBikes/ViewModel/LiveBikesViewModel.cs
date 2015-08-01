using DynamicData.Binding;
using DynamicRealTimeBikes.Common;
using DynamicRealTimeBikes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRealTimeBikes.ViewModel
{
    public class LiveBikesViewModel : AbstractNotifyPropertyChanged, IDisposable
    {
        private readonly IDisposable _cleanUp;
        private IObservableCollection<StationDto> _data = new ObservableCollectionExtended<StationDto>();

        public LiveBikesViewModel(IRealTimeModel model)
        {
            var loader = model.All;
        }

        public void Dispose()
        {
            _cleanUp.Dispose();
        }
    }
}
