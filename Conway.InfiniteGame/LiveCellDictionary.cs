using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Conway.InfiniteGame
{
    public class LiveCellDictionary : CellDictionary
    {
        public int NumberOfAliveNeighbours(Coordinate coordinate)
        {
            return NeighbourCoordinates.Count(neighbourCoordinate => ContainsKey(neighbourCoordinate + coordinate));
        }

        public CellDictionary ListOfDeadNeighbours(Coordinate coordinate)
        {
            var deadList = new CellDictionary();
            foreach (var ordinate in NeighbourCoordinates.Where(ordinate => !ContainsKey(ordinate + coordinate)))
                deadList.Add(ordinate + coordinate, new CellDead());
            return deadList;
        }
    }
}