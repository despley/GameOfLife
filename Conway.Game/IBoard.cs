namespace Conway.Game
{
    public interface IBoard
    {
        int Size { get; }
        ICell this[Coordinate coordinate] { get; set; }
        int NumberOfAliveNeighbours(Coordinate coordinate);
        IBoard CreateTransistion();
    }
}