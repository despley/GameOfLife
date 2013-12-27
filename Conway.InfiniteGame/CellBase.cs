using System.ComponentModel;

namespace Conway.InfiniteGame
{
    public abstract class CellBase
    {
       public abstract bool NextState(int numberOfNeighbours);
    }
}