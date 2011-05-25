using System;
using NUnit.Framework;
using ThirdSectorCalculator.ViewModels;

namespace ThirdSectorCalculator.Test
{
    [TestFixture]
    public class SectorTimeViewModelTest
    {
        [Test]
        public void ShouldConstructFromMilliseconds()
        {
            var viewModel = new SectorTimeViewModel(45123);

            Assert.That(viewModel.Seconds, Is.EqualTo(45));
            Assert.That(viewModel.Milliseconds, Is.EqualTo(123));
        }

        [Test]
        public void ShouldNotAllowSecondsLargerThanFiftyNine()
        {
            var viewModel = new SectorTimeViewModel { Seconds = 2 };

            Assert.That(() => viewModel.Seconds = 60, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Seconds must be between 0 and 59"));
        }

        [Test]
        public void ShouldNotAllowMinusSeconds()
        {
            var viewModel = new SectorTimeViewModel { Seconds = 0 };

            Assert.That(() => viewModel.Seconds = -1, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Seconds must be between 0 and 59"));
        }

        [Test]
        public void ShouldNotAllowMillesecondsLargerThanNineHundredsAndNintyNine()
        {
            var viewModel = new SectorTimeViewModel { Milliseconds = 2 };

            Assert.That(() => viewModel.Milliseconds = 1000, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Milliseconds must be between 0 and 999. Value is 1000"));
        }

        [Test]
        public void ShouldNotAllowMinusMilliseconds()
        {
            var viewModel = new SectorTimeViewModel { Milliseconds = 0 };

            Assert.That(() => viewModel.Milliseconds = -1, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Milliseconds must be between 0 and 999. Value is -1"));
        }

        [Test]
        public void ShouldConvertToMilliseconds()
        {
            var viewModel = new SectorTimeViewModel { Seconds = 45, Milliseconds = 555 };

            Assert.That(viewModel.ToMilliseconds(), Is.EqualTo(45555));
        }

        [Test]
        public void ShouldConvertToString()
        {
            var viewModel = new SectorTimeViewModel { Seconds = 45, Milliseconds = 555 };

            Assert.That(viewModel.ToString(), Is.EqualTo("45.555"));
        }
    }
}
