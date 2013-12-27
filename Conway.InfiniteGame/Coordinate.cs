using System.Linq.Expressions;

namespace Conway.InfiniteGame
{
    public struct Coordinate
    {
        public int Column;
        public int Row;
        public Coordinate(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public static Coordinate operator+(Coordinate coordinateA, Coordinate coordinateB)
        {
            return new Coordinate(coordinateA.Column + coordinateB.Column, coordinateA.Row + coordinateB.Row);
        }

        public override string ToString()
        {
            return string.Format("Column: {0}, Row: {1}", Column, Row);
        }
    }
}