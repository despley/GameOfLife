using System.Threading.Tasks;

namespace Conway.Game
{
    public class ParallelBoardService : BoardService
    {
        private readonly IBoardFactory _boardFactory;
        private readonly ICellFactory _cellFactory;
        public ParallelBoardService(IBoardFactory boardFactory, ICellFactory cellFactory) : base(boardFactory, cellFactory)
        {
            _boardFactory = boardFactory;
            _cellFactory = cellFactory;
        }

        public override IBoard CreateTransistion(IBoard currentBoard)
        {
            var futureBoard = _boardFactory.CreateBoard(currentBoard.Size, this);

            Parallel.For(0, currentBoard.Size, column => Parallel.For(0, currentBoard.Size, row =>
            {
                futureBoard[column, row] = _cellFactory.CreateCell(
                    currentBoard[column, row].NextState(
                        currentBoard.NumberOfAliveNeighbours(column, row)));
            }));
            return futureBoard;
        }

        public override int NumberOfAliveNeighbours(IBoard board, int x, int y)
        {
            return base.NumberOfAliveNeighbours(board, x, y);
            //var count = 0;
            //Parallel.For(-1, 2, column => Parallel.For(-1,2,row =>
            //{
            //    if (!board[x + column, y + row].IsAlive) return;
            //    if (!(x + column == x && y + row == y)) 
            //        count++;
            //}));
            //return count;
        }
    }
}