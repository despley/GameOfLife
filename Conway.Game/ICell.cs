namespace Conway.Game
{
    public interface ICell
    {
        bool NextState(int numberOfAliveNeighbours);
        bool IsAlive { get; }
    }
}