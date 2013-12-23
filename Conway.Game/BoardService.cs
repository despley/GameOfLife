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
                    futureBoard[column, row] = _cellFactory.CreateCell(
                                            currentBoard[column, row].NextState(
                                            currentBoard.NumberOfAliveNeighbours(column, row)));
                }
            }
            return futureBoard;
        }

        public virtual ICell CreateCell(bool isAlive)
        {
            return _cellFactory.CreateCell(isAlive);
        }

        public virtual int NumberOfAliveNeighbours(IBoard board, int column, int row)
        {
            var count = 0;
            for (var x = -1; x <= 1; x++)
                for (var y = -1; y <= 1; y++)
                {
                    if (!board[column + x, row + y].IsAlive) continue;
                    if (!(column + x == column && row + y == row)) count++;
                }
            return count;
        }
    }
}
