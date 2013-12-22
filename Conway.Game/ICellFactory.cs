namespace Conway.Game
{
    public interface ICellFactory
    {
        ICell CreateCell(bool isAlive);
    }
}