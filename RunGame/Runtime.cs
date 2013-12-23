using System;
using System.Text;
using Conway.Game;

namespace RunGame
{
    public class Runtime
    {
        private readonly IBoardService _boardService;
        public Runtime(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public void Go()
        {
            var board = _boardService.CreateBoard(50);
            board[new Coordinate(1, 32)] = _boardService.CreateCell(true);
            board[new Coordinate(2, 32)] = _boardService.CreateCell(true);
            board[new Coordinate(3, 32)] = _boardService.CreateCell(true);
            board[new Coordinate(3, 33)] = _boardService.CreateCell(true);
            board[new Coordinate(2, 34)] = _boardService.CreateCell(true);
            board[new Coordinate(27, 43)] = _boardService.CreateCell(true);
            board[new Coordinate(27, 44)] = _boardService.CreateCell(true);
            board[new Coordinate(27, 45)] = _boardService.CreateCell(true);
            for (int i = 34; i < 44; i++)
                board[new Coordinate(i,45)] = _boardService.CreateCell(true);
            var count = 0;
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            while (count < 10000)
            {
                Console.Clear();
                Console.Write(DrawBoard(board));
                board = board.CreateTransistion();
                count++;
            }  
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            Console.ReadKey();
        }

        private static string DrawBoard(IBoard board)
        {
            var sb = new StringBuilder();
            for (var row = 0; row < board.Size; row++)
            {
                for (var column = 0; column < board.Size; column++)
                {
                    sb.Append(board[new Coordinate(row, column)].IsAlive ? "*" : " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}