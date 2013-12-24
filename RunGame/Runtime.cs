using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
            var board = _boardService.CreateBoard(30, CreateCoordinates());
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            for(var i = 0; i< 10000; i++)
            {
                Console.Clear();
                Console.Write(DrawBoard(board));
                board = board.CreateTransistion();
                Thread.Sleep(100);
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
                    sb.Append(board[new Coordinate(column, row)].IsAlive ? "*" : " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private IList<Coordinate> CreateCoordinates()
        {
            var coordinates = new List<Coordinate>()
            {
                new Coordinate(1, 12),
                new Coordinate(2, 12),
                new Coordinate(3, 12),
                new Coordinate(3, 13),
                new Coordinate(3, 13),
                new Coordinate(2, 14),
                new Coordinate(27, 16),
                new Coordinate(27,17),
                new Coordinate(27, 18)
            };
            for (int i = 14; i < 24; i++)
                coordinates.Add(new Coordinate(i, 8));
            return coordinates;
        }
    }
}