using NUnit.Framework;
using ThirdSectorCalculator.ViewModels;

namespace ThirdSectorCalculator.Test
{
    [TestFixture]
    public class MainViewModelTest
    {
        [Test]
        public void ShouldCalculateThirdSectorFromLapTimeAndFirstAndSecondSectors()
        {
            var lapTime = new LapTimeViewModel {Minute = 1, Seconds = 45, Milliseconds = 674 }; // 105674 milliseconds
            var firstSector = new SectorTimeViewModel {Seconds = 35, Milliseconds = 342 };  // 35342 milliseconds
            var secondSector = new SectorTimeViewModel {Seconds = 42, Milliseconds = 714 }; // 42714 milliseconds

            var viewModel = new MainViewModel {LapTime = lapTime, FirstSector = firstSector, SecondSector = secondSector};

            var thirdSector = viewModel.ThirdSector;

            // 3rd sector should be 27618 milliseconds
            Assert.That(thirdSector.Seconds, Is.EqualTo(27));
            Assert.That(thirdSector.Milliseconds, Is.EqualTo(618));
        }
    }
}
