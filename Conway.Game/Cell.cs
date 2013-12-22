namespace Conway.Game
{
    public class Cell : ICell
    {

        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public bool NextState(int numberOfAliveNeighbours)
        {
            if (IsAlive)
                    return numberOfAliveNeighbours >= 2 && numberOfAliveNeighbours <= 3;
            return numberOfAliveNeighbours == 3;
        }

        public bool IsAlive { get; private set; }
    }
}
