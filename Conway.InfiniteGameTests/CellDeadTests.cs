using Conway.InfiniteGame;
using Xunit;

namespace Conway.InfiniteGameTests
{
    public class CellDeadTests
    {

        [Fact]
        public void AnyDeadCellWithExactlyThreeNeighboursBecomesALiveCell()
        {
            var cell = new CellDead();
            Assert.True(cell.NextState(3));
        }
    }
}