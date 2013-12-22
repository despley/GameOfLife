using System;
using System.Text;
using System.Threading;
using Conway.Game;

namespace RunGame
{
    public class Runtime
    {
        private readonly IBoardFactory _boardFactory;
        private readonly IBoardService _boardService;
        public Runtime(IBoardFactory boardFactory, IBoardService boardService)
        {
            _boardFactory = boardFactory;
            _boardService = boardService;
        }

        public void Go()
        {
            var board = _boardFactory.CreateBoard(50, _boardService);
            board[1, 32] = _boardService.CreateCell(true);
            board[2, 32] = _boardService.CreateCell(true);
            board[3, 32] = _boardService.CreateCell(true);
            board[3, 33] = _boardService.CreateCell(true);
            board[2, 34] = _boardService.CreateCell(true);
            board[27, 43] = _boardService.CreateCell(true);
            board[27, 44] = _boardService.CreateCell(true);
            board[27, 45] = _boardService.CreateCell(true);
            for (int i = 34; i < 44; i++)
                board[i, 45] = _boardService.CreateCell(true);
            var count = 0;
            Console.ReadKey();
            while (count < 1000)
            {
                Console.Clear();
                Console.Write(DrawBoard(board));
                board = board.CreateTransistion();
                Thread.Sleep(100);
                count++;
            }     
        }

        private static string DrawBoard(IBoard board)
        {
            var sb = new StringBuilder();
            for (var row = 0; row < board.Size; row++)
            {
                for (var column = 0; column < board.Size; column++)
                {
                    sb.Append(board[row, column].IsAlive ? "*" : " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}