namespace Conway.Game
{
    public interface IBoard
    {
        int Size { get; }
        ICell this[int column, int row] { get; set; }
        int NumberOfAliveNeighbours(int column, int row);
        IBoard CreateTransistion();
    }
}