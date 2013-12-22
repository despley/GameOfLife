namespace Conway.Game
{
    public class BoardFactory : IBoardFactory
    {
        public IBoard CreateBoard(int size, IBoardService boardService)
        {
            return new Board(size, boardService);
        }
    }
}