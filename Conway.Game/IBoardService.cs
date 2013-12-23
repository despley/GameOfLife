namespace Conway.Game
{
    public interface IBoardService
    {
        IBoard CreateTransistion(IBoard currentBoard);
        ICell CreateCell(bool isAlive);
        int NumberOfAliveNeighbours(IBoard board, int column, int row);
    }
}