namespace Conway.Game
{
    public interface IBoardFactory
    {
        IBoard CreateBoard(int size, IBoardService boardService);
    }
}