using System.Collections.Generic;
using System.Linq;

namespace Conway.InfiniteGame
{
    public class CellDictionary : Dictionary<Coordinate, CellBase>
    {
        internal readonly IList<Coordinate> NeighbourCoordinates = new List<Coordinate>()
        {   new Coordinate(-1,-1), 
            new Coordinate(-1,0), 
            new Coordinate(-1,1), 
            new Coordinate(0,-1), 
            new Coordinate(0, 1), 
            new Coordinate(1,-1), 
            new Coordinate(1,0), 
            new Coordinate(1,1)};
    }
}