namespace Conway.Game
{
    public interface IBoardService
    {
        IBoard CreateTransition(IBoard currentBoard);
        ICell CreateCell(bool isAlive);
        int NumberOfAliveNeighbours(IBoard board, Coordinate coordinate);
        IBoard CreateBoard(int size);
        IBoard CreateBoard(int size, Coordinate[] coordinates);

    }
}