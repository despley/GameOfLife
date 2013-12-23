using Conway.Game;
using Xunit;
using Xunit.Extensions;

namespace Conway.Test
{
    public class CellTests
    {
        [Theory, InlineData(1), InlineData(0), InlineData(-1)]
        public void AnyLiveCellWithFewerThanTwoLiveNeighboursDiesAsIfCausedByUnderPopulation(int numberOfNeighbours)
        {
            var cellFactory = new CellFactory();
            var cell = cellFactory.CreateCell(true);
            Assert.Equal(false, cell.NextState(numberOfNeighbours));
        }

        [Theory, InlineData(2), InlineData(3)]
        public void AnyLiveCellWithTwoOrThreeLiveNeighboursLivesOnToTheNextGen(int numberOfNeighbours)
        {
            var cellFactory = new CellFactory();
            var cell = cellFactory.CreateCell(true);
            Assert.Equal(true, cell.NextState(numberOfNeighbours));
        }

        [Theory, InlineData(4), InlineData(5)]
        public void AnyLiveCellWithMoreThanThreeLiveNeighboursDies(int numberOfNeighbours)
        {
            var cellFactory = new CellFactory();
            var cell = cellFactory.CreateCell(true);
            Assert.False(cell.NextState(numberOfNeighbours));
        }

        [Fact]
        public void AnyDeadCellWithExactlyThreeNeighboursBecomesALiveCell()
        {
            var cellFactory = new CellFactory();
            var cell = cellFactory.CreateCell(false);
            Assert.True(cell.NextState(3));
        }

    }
}
