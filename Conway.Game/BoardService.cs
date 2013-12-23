namespace Conway.Game
{
    public class BoardService : IBoardService
    {
        private readonly IBoardFactory _boardFactory;
        private readonly ICellFactory _cellFactory;
        public BoardService(IBoardFactory boardFactory, ICellFactory cellFactory)
        {
            _boardFactory = boardFactory;
            _cellFactory = cellFactory;
        }
        public virtual IBoard CreateTransition(IBoard currentBoard)
        {
            var futureBoard = _boardFactory.CreateBoard(currentBoard.Size, this);
            for (var column = 0; column < currentBoard.Size; column++)
            {
                for (var row = 0; row < currentBoard.Size; row++)
                {
                    futureBoard[new Coordinate(column, row)] = _cellFactory.CreateCell(
                                            currentBoard[new Coordinate(column, row)].NextState(
                                            currentBoard.NumberOfAliveNeighbours(new Coordinate(column, row))));
                }
            }
            return futureBoard;
        }

        public virtual ICell CreateCell(bool isAlive)
        {
            return _cellFactory.CreateCell(isAlive);
        }

        public virtual IBoard CreateBoard(int size)
        {
            return _boardFactory.CreateBoard(size, this);
        }


        public IBoard CreateBoard(int size, Coordinate[] coordinates)
        {
            var board = _boardFactory.CreateBoard(size, this);
            foreach (var coordinate in coordinates)
                board[coordinate] = _cellFactory.CreateCell(true);
            return board; 
        }

        public virtual int NumberOfAliveNeighbours(IBoard board, Coordinate coordinate)
        {
            var count = 0;
            for (var x = -1; x <= 1; x++)
                for (var y = -1; y <= 1; y++)
                {
                    if (!board[new Coordinate(coordinate.Column + x, coordinate.Row + y)].IsAlive) continue;
                    if (!(coordinate.Column + x == coordinate.Column && coordinate.Row + y == coordinate.Row)) count++;
                }
            return count;
        }
    }
}
