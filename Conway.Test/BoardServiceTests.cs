using System;
using System.Collections.Generic;
using Conway.Game;
using FakeItEasy;
using Xunit;

namespace Conway.Test
{
    public class BoardServiceTests
    {
        [Fact]
        public void EnsureNumberOfNeighboursIsCalcualtedCorrectly()
        {
            var board = A.Fake<IBoard>();
            var cellTrue = A.Fake<ICell>();
            var cellFactory = A.Fake<ICellFactory>();
            var cellFalse = A.Fake<ICell>();
            var boardFactory = A.Fake<IBoardFactory>();
            var boardService = new BoardService(boardFactory, cellFactory);
            A.CallTo(() => cellTrue.IsAlive).Returns(true);
            A.CallTo(() => cellFalse.IsAlive).Returns(false);
            A.CallTo(() => board[new Coordinate(0, 0)]).Returns(cellTrue);
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
            var boardService = new BoardService(boardFactory, cellFactory);
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

        [Fact]
        public void CanCreateBoardWithArrayOfCoordinates()
        {
            var cell = A.Fake<ICell>();
            var board = new BoardStubb();
            var cellFactory = A.Fake<ICellFactory>();
            var boardFactory = A.Fake<IBoardFactory>();
            var boardService = new BoardService(boardFactory, cellFactory);
            var coordinate = new[]
            {
                new Coordinate(0,0),new Coordinate(1,1) 
            };
            A.CallTo(() => boardFactory.CreateBoard(5, boardService)).Returns(board);
            A.CallTo(() => cellFactory.CreateCell(true)).Returns(cell);
            A.CallTo(() => cell.IsAlive).Returns(true);
            var newBoard = boardService.CreateBoard(5, coordinate);
            A.CallTo(() => boardFactory.CreateBoard(5, boardService)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => cellFactory.CreateCell(true)).MustHaveHappened(Repeated.Exactly.Twice);
            Assert.Equal(cell, newBoard[new Coordinate(0, 0)]);
            Assert.Equal(cell, newBoard[new Coordinate(1, 1)]);
            Assert.Equal(null, newBoard[new Coordinate(0, 1)]);
        }

        [Fact]
        public void CanCreateBoardWithIListOfCoordinates()
        {
            var cell = A.Fake<ICell>();
            var board = new BoardStubb();
            var cellFactory = A.Fake<ICellFactory>();
            var boardFactory = A.Fake<IBoardFactory>();
            var boardService = new BoardService(boardFactory, cellFactory);
            var coordinate = new List<Coordinate>
            {
                new Coordinate(0,0),new Coordinate(1,1) 
            };
            A.CallTo(() => boardFactory.CreateBoard(5, boardService)).Returns(board);
            A.CallTo(() => cellFactory.CreateCell(true)).Returns(cell);
            A.CallTo(() => cell.IsAlive).Returns(true);
            var newBoard = boardService.CreateBoard(5, coordinate);
            A.CallTo(() => boardFactory.CreateBoard(5, boardService)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => cellFactory.CreateCell(true)).MustHaveHappened(Repeated.Exactly.Twice);
            Assert.Equal(cell, newBoard[new Coordinate(0, 0)]);
            Assert.Equal(cell, newBoard[new Coordinate(1, 1)]);
            Assert.Equal(null, newBoard[new Coordinate(0, 1)]);
        }

        [Fact]
        public void CanCreateBoardAndCells()
        {
            var boardFactory = A.Fake<IBoardFactory>();
            var cellFactory = A.Fake<ICellFactory>();
            var boardService = new BoardService(boardFactory, cellFactory);
            boardService.CreateCell(true);
            boardService.CreateBoard(50);
            A.CallTo(() => boardFactory.CreateBoard(50, boardService)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => cellFactory.CreateCell(true)).MustHaveHappened(Repeated.Exactly.Once);

        }
    }

    internal class BoardStubb : IBoard
    {
        private ICell[,] _cells = new ICell[5,5];
        public int Size { get; private set; }

        public ICell this[Coordinate coordinate]
        {
            get { return _cells[coordinate.Column, coordinate.Row]; }
            set { _cells[coordinate.Column, coordinate.Row] = value; }
        }

        public int NumberOfAliveNeighbours(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public IBoard CreateTransistion()
        {
            throw new NotImplementedException();
        }
    }
}