using System;

namespace Conway.Game
{
    public class Board : IBoard
    {
        private readonly IBoardService _boardService;
        private readonly ICell [,] _board ;
        
        public int Size { get; private set; }

        public Board(int size, IBoardService boardService)
        {
            if (size < 1)
                throw new ArgumentException("The size of the board must be 1 or greater");
            Size = size;
            _boardService = boardService;
            var cells = new ICell[size, size];
            _board = cells;
            InitialiseBoard();
        }
        public ICell this[int x, int y]
        {
            get
            {
                if(x < 0 || x >= Size || y<0 || y >=Size )
                    return _boardService.CreateCell(false);
                return _board[x,y];
            }
            set { _board[x, y] = value; }
        }

        private void InitialiseBoard()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    _board[i, j] = _boardService.CreateCell(false);
                }
            }
        }

        public int NumberOfAliveNeighbours(int x, int y)
        {
            return _boardService.NumberOfAliveNeighbours(this, x, y);
        }

        public IBoard CreateTransistion()
        {
            return _boardService.CreateTransistion(this);
        }
    }
}
