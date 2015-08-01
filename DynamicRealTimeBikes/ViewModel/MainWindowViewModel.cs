﻿using DynamicData.Binding;
using DynamicRealTimeBikes.Common;
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
        private LiveBikesViewModel _liveBikesViewModel;

        public MainWindowViewModel()
        {
            Dispatcher dispatcher = Application.Current.Dispatcher;
            var schProv = new SchedulerProvider(dispatcher);
            var realTimeModel = new RealTimeModel(schProv);
            _liveBikesViewModel = new LiveBikesViewModel(realTimeModel);

        }

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