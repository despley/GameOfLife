using System;
using System.Text;
using System.Threading;
using Conway.Game;

namespace RunGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Container.GetRuntime().Go();
        }
    }
}
