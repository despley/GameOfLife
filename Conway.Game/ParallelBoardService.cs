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

        public new IBoard CreateTransistion(IBoard currentBoard)
        {
            var futureBoard = _boardFactory.CreateBoard(currentBoard.Size, this);

            Parallel.For(0, currentBoard.Size, column => 
            {
                for (var row = 0; row < currentBoard.Size; row++)
                {
                    futureBoard[column, row] = _cellFactory.CreateCell(
                                            currentBoard[column, row].NextState(
                                            currentBoard.NumberOfAliveNeighbours(column, row)));
                }
            });
            return futureBoard;
        }
    }
}