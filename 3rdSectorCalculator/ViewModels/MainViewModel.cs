using System;
using System.ComponentModel;

namespace ThirdSectorCalculator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
        }

        public LapTimeViewModel LapTime { get; set; }
        public SectorTimeViewModel FirstSector { get; set; }
        public SectorTimeViewModel SecondSector { get; set; }
        public SectorTimeViewModel ThirdSector { get; private set; }

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