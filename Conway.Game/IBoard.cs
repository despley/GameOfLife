namespace Conway.Game
{
    public interface IBoard
    {
        int Size { get; }
        ICell this[int x, int y] { get; set; }
        int NumberOfAliveNeighbours(int x, int y);
        IBoard CreateTransistion();
    }
}