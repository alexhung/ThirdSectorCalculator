using System;
using NUnit.Framework;
using ThirdSectorCalculator.ViewModels;

namespace ThirdSectorCalculator.Test
{
    [TestFixture]
    public class LapTimeViewModelTest
    {
        [Test]
        public void ShouldConstructFromMilliseconds()
        {
            var viewModel = new LapTimeViewModel(105123);

            Assert.That(viewModel.Minute, Is.EqualTo(1));
            Assert.That(viewModel.Seconds, Is.EqualTo(45));
            Assert.That(viewModel.Milliseconds, Is.EqualTo(123));
        }

        [Test]
        public void ShouldSetLapTime()
        {
            var lapTimeViewModel = new LapTimeViewModel { Minute = 1, Seconds = 55, Milliseconds = 444};

            Assert.That(lapTimeViewModel.Minute, Is.EqualTo(1));
            Assert.That(lapTimeViewModel.Seconds, Is.EqualTo(55));
            Assert.That(lapTimeViewModel.Milliseconds, Is.EqualTo(444));
            Assert.That(lapTimeViewModel.ToString(), Is.EqualTo("1:55.444"));
        }

        [Test]
        public void ShouldNotAllowMinuteLargerThanTwo()
        {
            var lapTimeViewModel = new LapTimeViewModel { Minute = 2 };

            Assert.That(() => lapTimeViewModel.Minute = 3, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Minute cannot be larger than 2"));
        }

        [Test]
        public void ShouldNotAllowZeroOrMinusMinute()
        {
            var lapTimeViewModel = new LapTimeViewModel();

            Assert.That(() => lapTimeViewModel.Minute = -1, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Minute must be larger than 0"));
            Assert.That(() => lapTimeViewModel.Minute = 0, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Minute must be larger than 0"));
        }

        [Test]
        public void ShouldNotAllowSecondsLargerThanFiftyNine()
        {
            var lapTimeViewModel = new LapTimeViewModel { Seconds = 2 };

            Assert.That(() => lapTimeViewModel.Seconds = 60, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Seconds must be between 0 and 59"));
        }

        [Test]
        public void ShouldNotAllowMinusSeconds()
        {
            var lapTimeViewModel = new LapTimeViewModel { Seconds = 0 };

            Assert.That(() => lapTimeViewModel.Seconds = -1, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Seconds must be between 0 and 59"));
        }

        [Test]
        public void ShouldNotAllowMillesecondsLargerThanNineHundredsAndNintyNine()
        {
            var lapTimeViewModel = new LapTimeViewModel { Milliseconds = 2 };

            Assert.That(() => lapTimeViewModel.Milliseconds = 1000, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Milliseconds must be between 0 and 999"));
        }

        [Test]
        public void ShouldNotAllowMinusMilliseconds()
        {
            var lapTimeViewModel = new LapTimeViewModel { Milliseconds = 0 };

            Assert.That(() => lapTimeViewModel.Milliseconds = -1, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Milliseconds must be between 0 and 999"));
        }

        [Test]
        public void ShouldConvertToMilliseconds()
        {
            var lapTimeViewModel = new LapTimeViewModel {Minute = 1, Seconds = 45, Milliseconds = 555};
            
            Assert.That(lapTimeViewModel.ToMilliseconds(), Is.EqualTo(105555));
        }
    }
}
