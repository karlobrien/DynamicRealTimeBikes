using DynamicData.Binding;
using DynamicRealTimeBikes.Common;
using DynamicRealTimeBikes.Common.Service;
using DynamicRealTimeBikes.Infrastructure;
using DynamicRealTimeBikes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DynamicRealTimeBikes.ViewModel
{
    public class MainWindowViewModel : AbstractNotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Dispatcher dispatcher = Application.Current.Dispatcher;
            var schProv = new SchedulerProvider(dispatcher);

            IDataRequest dataRequest = new DataRequest();
            IBikeService bikeService = new BikeService(dataRequest);
            IRealTimeModel realTimeModel = new RealTimeModel(schProv, bikeService);
            _liveBikesViewModel = new LiveBikesViewModel(realTimeModel);
        }

        private LiveBikesViewModel _liveBikesViewModel;
        public LiveBikesViewModel LiveBikesViewModel
        {
            get { return _liveBikesViewModel; }
            set
            {
                SetAndRaise(ref _liveBikesViewModel, value);
            }
        }
    }
}
