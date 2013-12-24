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
            A.CallTo(() => board[new Coordinate(0,0)]).Returns(cellTrue);
            A.CallTo(() => board[new Coordinate(0, 1)]).Returns(cellTrue);
            A.CallTo(() => board[new Coordinate(0, 2)]).Returns(cellTrue);
            A.CallTo(() => board[new Coordinate(1, 0)]).Returns(cellTrue);
            A.CallTo(() => board[new Coordinate(1, 1)]).Returns(cellTrue);
            A.CallTo(() => board[new Coordinate(1, 2)]).Returns(cellTrue);
            A.CallTo(() => board[new Coordinate(2, 0)]).Returns(cellTrue);
            A.CallTo(() => board[new Coordinate(2, 1)]).Returns(cellTrue);
            A.CallTo(() => board[new Coordinate(2, 2)]).Returns(cellTrue);
            Assert.Equal(8, boardService.NumberOfAliveNeighbours(board, new Coordinate(1,1)));
        }

        [Fact]
        public void CheckTransistionGeneratesNewBoardCorrectly()
        {
            var cell = A.Fake<ICell>();
            var currentBoard = A.Fake<IBoard>();
            var futureBoard = A.Fake<IBoard>();
            var cellFactory = A.Fake<ICellFactory>();
            var boardFactory = A.Fake<IBoardFactory>();
            var boardService = new ParallelBoardService(boardFactory, cellFactory);
            var coordinate = new Coordinate(0, 0);
            A.CallTo(() => currentBoard.Size).Returns(1);
            A.CallTo(() => currentBoard[coordinate]).Returns(cell);
            A.CallTo(() => currentBoard.NumberOfAliveNeighbours(coordinate)).Returns(0);
            A.CallTo(() => cell.NextState(0)).Returns(false);
            A.CallTo(() => cellFactory.CreateCell(false)).Returns(cell);
            A.CallTo(() => boardFactory.CreateBoard(1, boardService)).Returns(futureBoard);
            boardService.CreateTransition(currentBoard);
            A.CallTo(() => cellFactory.CreateCell(false)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => currentBoard.Size).MustHaveHappened(Repeated.AtLeast.Once);
            A.CallTo(() => cell.NextState(0)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => currentBoard.NumberOfAliveNeighbours(new Coordinate(0, 0))).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => boardFactory.CreateBoard(1, boardService)).MustHaveHappened(Repeated.Exactly.Once);

        }
    }
}