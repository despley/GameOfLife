using Conway.Game;
using FakeItEasy;
using Xunit;

namespace Conway.Test
{
    public class ParallelBoardServiceTests
    {
        [Fact]
        public void EnsureNumberOfNeighboursIsCalcualtedCorrectly()
        {
            var board = A.Fake<IBoard>();
            var cellTrue = A.Fake<ICell>();
            var cellFactory = A.Fake<ICellFactory>();
            var cellFalse = A.Fake<ICell>();
            var boardFactory = A.Fake<IBoardFactory>();
            var boardService = new ParallelBoardService(boardFactory, cellFactory);
            A.CallTo(() => cellTrue.IsAlive).Returns(true);
            A.CallTo(() => cellFalse.IsAlive).Returns(false);
            A.CallTo(() => board[0, 0]).Returns(cellTrue);
            A.CallTo(() => board[0, 1]).Returns(cellTrue);
            A.CallTo(() => board[0, 2]).Returns(cellTrue);
            A.CallTo(() => board[1, 0]).Returns(cellTrue);
            A.CallTo(() => board[1, 1]).Returns(cellTrue);
            A.CallTo(() => board[1, 2]).Returns(cellTrue);
            A.CallTo(() => board[2, 0]).Returns(cellTrue);
            A.CallTo(() => board[2, 1]).Returns(cellTrue);
            A.CallTo(() => board[2, 2]).Returns(cellTrue);
            Assert.Equal(8, boardService.NumberOfAliveNeighbours(board, 1, 1));
        } 
    }
}