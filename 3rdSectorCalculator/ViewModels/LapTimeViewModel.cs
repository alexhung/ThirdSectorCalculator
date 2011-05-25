using System;

namespace ThirdSectorCalculator.ViewModels
{
    public class LapTimeViewModel
    {
        public LapTimeViewModel()
        {
            Minute = 1;
            Seconds = 0;
            Milliseconds = 0;
        }

        private int _minute;
        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Minute must be larger than 0");
                }
                if (value > 2)
                {
                    throw new ArgumentException("Minute cannot be larger than 2");
                }

                _minute = value;
            }
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
                    throw new ArgumentException("Milliseconds must be between 0 and 999");
                }

                _milliseconds = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}.{2}", Minute, Seconds, Milliseconds);
        }

        public int ToMilliseconds()
        {
            return (Minute * 60 * 1000) + (Seconds * 1000) + Milliseconds;
        }
    }
}