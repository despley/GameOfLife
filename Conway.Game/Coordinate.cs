namespace Conway.Game
{
    public struct Coordinate
    {
        public int Column;
        public int Row;
        public Coordinate(int column, int row)
        {
            Row = row;
            Column = column;
        }
    }
}