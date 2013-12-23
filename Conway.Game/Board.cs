using System;

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
        public ICell this[int column, int row]
        {
            get
            {
                if(column < 0 || column >= Size || row<0 || row >=Size )
                    return _boardService.CreateCell(false);
                return _board[column,row];
            }
            set { _board[column, row] = value; }
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

        public int NumberOfAliveNeighbours(int column, int row)
        {
            return _boardService.NumberOfAliveNeighbours(this, column, row);
        }

        public IBoard CreateTransistion()
        {
            return _boardService.CreateTransition(this);
        }
    }
}
