using Conway.InfiniteGame;
using Xunit;
using Xunit.Extensions;

namespace Conway.InfiniteGameTests
{
    public class CellLiveTests
    {
        [Theory, InlineData(1), InlineData(0), InlineData(-1)]
        public void AnyLiveCellWithFewerThanTwoLiveNeighboursDiesAsIfCausedByUnderPopulation(int numberOfNeighbours)
        {
            var cell = new CellLive();
            Assert.Equal(false, cell.NextState(numberOfNeighbours));
        }

        [Theory, InlineData(2), InlineData(3)]
        public void AnyLiveCellWithTwoOrThreeLiveNeighboursLivesOnToTheNextGen(int numberOfNeighbours)
        {

            var cell = new CellLive();
            Assert.Equal(true, cell.NextState(numberOfNeighbours));
        }
        [Theory, InlineData(4), InlineData(5)]
        public void AnyLiveCellWithMoreThanThreeLiveNeighboursDies(int numberOfNeighbours)
        {

            var cell = new CellLive();
            Assert.False(cell.NextState(numberOfNeighbours));
        }
    }

}