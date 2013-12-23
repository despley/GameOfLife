using System;
using Conway.Game;
using FakeItEasy;
using Xunit;
using Xunit.Extensions;

namespace Conway.Test
{
    public class BoardTests
    {

        [Theory, InlineData(1), InlineData(3), InlineData(32)]
        public void CheckBoardIsInitialisedWithAllDeadCellsCreated(int size)
        {
            var boardService = A.Fake<IBoardService>();
            new Board(size, boardService);
            A.CallTo(() => boardService.CreateCell(false)).MustHaveHappened(Repeated.Exactly.Times(size * size));
        }

        [Theory, InlineData(0), InlineData(-1)]
        public void CreatingANegativeOrZeroBoardSizeCausesAnException(int size)
        {
            var boardService = A.Fake<IBoardService>();
            var ex = Assert.Throws<ArgumentException>(() => new Board(size, boardService));
            Assert.Equal("The size of the board must be 1 or greater", ex.Message);
        }

        [Theory, InlineData(-1,-1, 1), InlineData(2, 2, 1)]
        public void EnsureCellRequestedOutsideOfGridReturnsDeadCell(int x, int y, int size)
        {
            var boardService = A.Fake<IBoardService>();
            var board = new Board(size, boardService);
            Assert.False(board[x,y].IsAlive);
        }

        [Fact]
        public void SetAndRetrieveALiveCell()
        {
            var boardService = A.Fake<IBoardService>();
            var board = new Board(1, boardService);
            board[0,0] = new Cell(true);
            Assert.True(board[0,0].IsAlive);
        }

        [Fact]
        public void EnsureBoardServiceIsCalledWhenAskingForNumberOfNeighbours()
        {
            var boardService = A.Fake<IBoardService>();
            var board = new Board(1, boardService);
            A.CallTo(() => boardService.NumberOfAliveNeighbours(board, 0, 0)).Returns(1);
            var i = board.NumberOfAliveNeighbours(0, 0);
            Assert.Equal(1, i);
            A.CallTo(() => boardService.NumberOfAliveNeighbours(board, 0, 0)).MustHaveHappened(Repeated.Exactly.Once);
        }


        [Fact]
        public void EnsureBoardServiceIsCalledWhenAskingForBoardTransistion()
        {
            var boardService = A.Fake<IBoardService>();
            var futureBoard = A.Fake<IBoard>();
            var board = new Board(1, boardService);
            A.CallTo(() => boardService.CreateTransition(board)).Returns(futureBoard);
            board.CreateTransistion();
            A.CallTo(() => boardService.CreateTransition(board)).MustHaveHappened(Repeated.Exactly.Once);
        }

    }


}
