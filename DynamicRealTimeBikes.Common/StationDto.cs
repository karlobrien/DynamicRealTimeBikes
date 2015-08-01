using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRealTimeBikes.Common
{
    public class StationDto : AbstractNotifyPropertyChanged
    {
        private int _number;
        public int Number 
        {
            get { return _number; }
            set
            {
                SetAndRaise(ref _number, value);
            }
        }

        private string _contractName;
        public string ContractName 
        {
            get { return _contractName; }
            set
            {
                SetAndRaise(ref _contractName, value);
            }
        }

        private string _name;
        public string Name 
        {
            get { return _name; }
            set
            {
                SetAndRaise(ref _name, value);
            }
        }

        private string _address;
        public string Address 
        {
            get { return _address; }
            set
            {
                SetAndRaise(ref _address, value);
            }
        }

        private Pos _position;
        public Pos Position 
        {
            get { return _position; }
            set
            {
                SetAndRaise(ref _position, value);
            }
        }

        private bool _banking;
        public bool Banking 
        {
            get { return _banking; }
            set
            {
                SetAndRaise(ref _banking, value);
            }
        }

        private string _bonus;
        public string Bonus 
        {
            get { return _bonus; }
            set
            {
                SetAndRaise(ref _bonus, value);
            }
        }

        private string _status;
        public string Status 
        {
            get { return _status; }
            set
            {
                SetAndRaise(ref _status, value);
            }
        }

        private string _bikeStands;
        public string Bike_Stands 
        {
            get { return _bikeStands; }
            set
            {
                SetAndRaise(ref _bikeStands, value);
            }
        }

        private string _availableBikeStands;
        public string Available_Bike_Stands 
        {
            get { return _availableBikeStands; }
            set
            {
                SetAndRaise(ref _availableBikeStands, value);
            }
        }

        private string _availableBikes;
        public string Available_Bikes 
        {
            get { return _availableBikes; }
            set
            {
                SetAndRaise(ref _availableBikes, value);
            }
        }

        private DateTime _timestamp;
        public DateTime TimeStamp 
        {
            get { return _timestamp; }
            set
            {
                SetAndRaise(ref _timestamp, value);
            }
        }
    }

    public class Pos : AbstractNotifyPropertyChanged
    {
        private decimal _lat;
        public decimal Lat 
        {
            get { return _lat; }
            set
            {
                SetAndRaise(ref _lat, value);
            }
        }

        private decimal _lng;
        public decimal Lng 
        {
            get { return _lng; }
            set
            {
                SetAndRaise(ref _lng, value);
            }
        }
    }
}
