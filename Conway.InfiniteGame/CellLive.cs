namespace Conway.InfiniteGame
{
    public class CellLive : CellBase
    {
        public override bool NextState(int numberOfNeighbours)
        {
            return numberOfNeighbours >= 2 && numberOfNeighbours <=3;
        }
    }
}