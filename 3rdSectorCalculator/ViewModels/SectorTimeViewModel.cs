using System;

namespace ThirdSectorCalculator.ViewModels
{
    public class SectorTimeViewModel
    {
        public SectorTimeViewModel()
        {
            Seconds = 0;
            Milliseconds = 0;
        }

        public SectorTimeViewModel(int milliseconds)
        {
            Seconds = Math.Abs(milliseconds / 1000);
            Milliseconds = milliseconds % 1000;
        }

        private int _seconds;
        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Seconds must be between 0 and 59");
                }

                _seconds = value;
            }
        }

        private int _milliseconds;
        public int Milliseconds
        {
            get { return _milliseconds; }
            set
            {
                if (value < 0 || value > 999)
                {
                    throw new ArgumentException(string.Format("Milliseconds must be between 0 and 999. Value is {0}", value));
                }

                _milliseconds = value;
            }
        }

        public int ToMilliseconds()
        {
            return (Seconds*1000) + Milliseconds;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", Seconds, Milliseconds);
        }
    }
}