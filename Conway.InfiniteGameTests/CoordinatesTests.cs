using System.Runtime.InteropServices;
using Conway.InfiniteGame;
using Xunit;

namespace Conway.InfiniteGameTests
{
    public class CoordinatesTests
    {
        [Fact]
        public void CheckThatCoordinatesAreCompareable()
        {
            var coord1 = new Coordinate(1, 1);
            var coord2 = new Coordinate(1, 1);
            Assert.Equal(coord1, coord2);
        }

        [Fact]
        public void AddingTwoCoordinatesTogetherCalculatesTrueCoordsValues()
        {
            var coords1 = new Coordinate(1, 1);
            var coords2 = new Coordinate(-1, -1);
            Assert.Equal(new Coordinate(0,0), coords1 + coords2);
        }
    }
}