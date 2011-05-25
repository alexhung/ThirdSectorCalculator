using System;
using System.ComponentModel;

namespace ThirdSectorCalculator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public LapTimeViewModel LapTime { get; set; }
        public SectorTimeViewModel FirstSector { get; set; }
        public SectorTimeViewModel SecondSector { get; set; }
        public SectorTimeViewModel ThirdSector
        {
            get
            {
                var thirdSectorInMilliseconds = LapTime.ToMilliseconds() - (FirstSector.ToMilliseconds() + SecondSector.ToMilliseconds());
                return new SectorTimeViewModel(thirdSectorInMilliseconds);
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