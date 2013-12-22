using Conway.Game;
using FakeItEasy;
using Xunit;

namespace Conway.Test
{
    public class BoardFactoryTests
    {
        [Fact]
        public void ShouldCreateBoard()
        {
            var boardFactory = new BoardFactory();
            var board = boardFactory.CreateBoard(1, A.Fake<BoardService>());
            Assert.Equal(1, board.Size);
        }
    }
}