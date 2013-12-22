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
        public virtual IBoard CreateTransistion(IBoard currentBoard)
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

        public virtual int NumberOfAliveNeighbours(IBoard board, int x, int y)
        {
            var count = 0;
            for (var column = -1; column <= 1; column++)
                for (var row = -1; row <= 1; row++)
                {
                    if (!board[x + column, y + row].IsAlive) continue;
                    if (!(x + column == x && y + row == y)) count++;
                }
            return count;
        }
    }
}
