using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestRobo
{
    [TestFixture]
    public class RoboPositiveTests
    {
        [Test]
        [TestCaseSource(nameof(AddBrowserConfs))]
        public void RoboCorrectPositionTest(int positionX, int positionY, string facing)
        {


        }

        private static IEnumerable<TestCaseData> AddBrowserConfs()
        {
            yield return new TestCaseData(1, 1, "NORTH");
            yield return new TestCaseData(4, 1, "EAST");
            yield return new TestCaseData(1, 4, "WEST");
            yield return new TestCaseData(4, 4, "SOUTH");
        }

    }
}
