using System;
using System.Collections.Generic;
using System.Diagnostics;
using Conway.InfiniteGame;
using Xunit;

namespace Conway.InfiniteGameTests
{
    public class LiveCellDictionaryTests
    {

        [Fact]
        public void LiveCellDictionaryCanAddUniqueCells()
        {
            var board = new LiveCellDictionary {{new Coordinate(1, 1), new CellLive()}};
            Assert.Equal(1, board.Count);
        }

        [Fact]
        public void LiveCellDictionaryThrowsErrorIfCellIsAddedToExistingCoordinate()
        {
            var board = new LiveCellDictionary {{new Coordinate(1, 1), new CellLive()}};
            Assert.Throws<ArgumentException>(() => board.Add(new Coordinate(1, 1), new CellLive()));
            Assert.Equal(1, board.Count);  
        }

        [Fact]
        public void LiveCellDictionaryWithOnlyOneCellChecksAllOfItsNeighboursToSeeIfTheyAreAlive()
        {
            var board = new LiveCellDictionary();
            Assert.Equal(0, board.NumberOfAliveNeighbours(new Coordinate(1, 1)));
        }

        [Fact]
        public void LiveCellDictionaryWithTwoCellsChecksAllOfItsNeighboursToSeeIfTheyAreAlive()
        {
            var board = new LiveCellDictionary { { new Coordinate(10, 10), new CellLive() }, { new Coordinate(9, 9), new CellLive() } };
            Assert.Equal(1, board.NumberOfAliveNeighbours(new Coordinate(10, 10)));
        }

        [Fact]
        public void LiveCellDictionaryWithThreeCellsChecksAllOfItsNeighboursToSeeIfTheyAreAlive()
        {
            var board = new LiveCellDictionary { 
                { new Coordinate(10, 10), new CellLive() }, 
                { new Coordinate(9, 9), new CellLive() }, 
                { new Coordinate(11, 11), new CellLive() } };
                Assert.Equal(2, board.NumberOfAliveNeighbours(new Coordinate(10, 10)));
        }

        [Fact]
        public void LiveCellDictionaryReturnsDeadCellList()
        {
            var listOfDeadNeighbours = new DeadCellDictionary
            {
                {new Coordinate(9, 10), new CellDead()},
                {new Coordinate(9, 11), new CellDead()},
                {new Coordinate(10, 9), new CellDead()},
                {new Coordinate(10, 11), new CellDead()},
                {new Coordinate(11, 9), new CellDead()},
                {new Coordinate(11, 10), new CellDead()}
            };

            var board = new LiveCellDictionary { 
                { new Coordinate(10, 10), new CellLive() }, 
                { new Coordinate(9, 9), new CellLive() }, 
                { new Coordinate(11, 11), new CellLive() } };
            var returningList = board.ListOfDeadNeighbours(new Coordinate(10, 10));
            foreach (var ordinate in returningList.Keys)         
                Assert.True(listOfDeadNeighbours.ContainsKey(ordinate));
            
        }

    }
}