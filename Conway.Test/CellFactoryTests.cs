using Conway.Game;
using Xunit;
using Xunit.Extensions;

namespace Conway.Test
{
    public class CellFactoryTests
    {
        [Theory, InlineData(false), InlineData(true)]
        public void TestCellCreation(bool cellAlive)
        {
            var engine = new CellFactory();
            Assert.Equal(cellAlive, engine.CreateCell(cellAlive).IsAlive);
        }
    }
}