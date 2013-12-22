namespace Conway.Game
{
    public class CellFactory : ICellFactory
    {
        public ICell CreateCell(bool isAlive)
        {
            return new Cell(isAlive);
        }
    }
}