using System;
using System.Security.Cryptography.X509Certificates;

namespace Conway.Game
{
    public class Board : IBoard
    {
        private readonly IBoardService _boardService;
        private readonly ICell [,] _board ;
        
        public int Size { get; private set; }

        internal Board(int size, IBoardService boardService)
        {
            if (size < 1)
                throw new ArgumentException("The size of the board must be 1 or greater");
            Size = size;
            _boardService = boardService;
            _board = new ICell[size, size];
            InitialiseBoard();
        }
        public ICell this[Coordinate coordinate]
        {
            get
            {
                if (coordinate.Column < 0 || coordinate.Column >= Size || coordinate.Row < 0 || coordinate.Row >= Size)
                    return _boardService.CreateCell(false);
                return _board[coordinate.Column,coordinate.Row];
            }
            set { _board[coordinate.Column, coordinate.Row] = value; }
        }

        private void InitialiseBoard()
        {
            for (var column = 0; column < Size; column++)
            {
                for (var row = 0; row < Size; row++)
                {
                    _board[column, row] = _boardService.CreateCell(false);
                }
            }
        }

        public int NumberOfAliveNeighbours(Coordinate coordinate)
        {
            return _boardService.NumberOfAliveNeighbours(this, coordinate);
        }

        public IBoard CreateTransistion()
        {
            return _boardService.CreateTransition(this);
        }
    }
}
