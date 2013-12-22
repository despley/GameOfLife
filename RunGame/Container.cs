using System;
using Autofac;
using Conway.Game;

namespace RunGame
{
    public class Container
    {
        public static Runtime GetRuntime()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CellFactory>().As<ICellFactory>();
            builder.RegisterType<BoardFactory>().As<IBoardFactory>();
            builder.RegisterType<ParallelBoardService>().As<IBoardService>();
            builder.RegisterType<Board>().As<IBoard>();
            builder.RegisterType<Runtime>();
            var container = builder.Build();
            return container.Resolve<Runtime>();
        }
    }
}