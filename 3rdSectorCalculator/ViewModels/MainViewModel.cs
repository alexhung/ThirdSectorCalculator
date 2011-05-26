using System;
using System.ComponentModel;

namespace ThirdSectorCalculator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private LapTimeViewModel _lapTime;
        public LapTimeViewModel LapTime
        {
            get { return _lapTime; }
            set
            {
                if (_lapTime != value)
                    NotifyPropertyChanged("LapTimeViewModel");

                _lapTime = value;
            }
        }

        private SectorTimeViewModel _firstSector;
        public SectorTimeViewModel FirstSector
        {
            get { return _firstSector; }
            set
            {
                if (_firstSector != value)
                    NotifyPropertyChanged("FirstSector");

                _firstSector = value;
            }
        }

        private SectorTimeViewModel _secondSector;
        public SectorTimeViewModel SecondSector
        {
            get { return _secondSector; }
            set
            {
                if (_secondSector != value)
                    NotifyPropertyChanged("SecondSector");

                _secondSector = value;
            }
        }

        public SectorTimeViewModel ThirdSector
        {
            get
            {
                var thirdSectorInMilliseconds = LapTime.ToMilliseconds() - (FirstSector.ToMilliseconds() + SecondSector.ToMilliseconds());
                return thirdSectorInMilliseconds >= 60000 ? new SectorTimeViewModel(0) : new SectorTimeViewModel(thirdSectorInMilliseconds);
            }
        }

        public MainViewModel()
        {
            LapTime = new LapTimeViewModel();
            FirstSector = new SectorTimeViewModel();
            SecondSector = new SectorTimeViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}