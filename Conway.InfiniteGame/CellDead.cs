namespace Conway.InfiniteGame
{
    public class CellDead : CellBase
    {
        public override bool NextState(int numberOfNeighbours)
        {
            return numberOfNeighbours == 3;
        }
    }
}