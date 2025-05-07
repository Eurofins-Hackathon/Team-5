using Battleship;
using Xunit;

namespace BattleshipTests
{
    public class GameBoardTests
    {
        [Fact]
        public void InitializeBoard_ShouldFillBoardWithWater()
        {
            // Arrange
            var board = new GameBoard();

            // Act
            board.InitializeBoard();

            // Assert
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Assert.Equal('~', board.GetCell(i, j)); // Assuming GetCell is implemented for testing
                }
            }
        }

        [Fact]
        public void PlaceShip_ShouldPlaceShipAtValidPosition()
        {
            // Arrange
            var board = new GameBoard();

            // Act
            bool result = board.PlaceShip(0, 0);

            // Assert
            Assert.True(result);
            Assert.Equal('S', board.GetCell(0, 0)); // Assuming GetCell is implemented for testing
        }

        [Fact]
        public void PlaceShip_ShouldNotPlaceShipAtOccupiedPosition()
        {
            // Arrange
            var board = new GameBoard();
            board.PlaceShip(0, 0);

            // Act
            bool result = board.PlaceShip(0, 0);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsAllShipsSunk_ShouldReturnTrueWhenAllShipsAreSunk()
        {
            // Arrange
            var board = new GameBoard();
            board.PlaceShip(0, 0);
            board.MarkHit(0, 0);

            // Act
            bool result = Program.IsAllShipsSunk(board);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsAllShipsSunk_ShouldReturnFalseWhenShipsRemain()
        {
            // Arrange
            var board = new GameBoard();
            board.PlaceShip(0, 0);

            // Act
            bool result = Program.IsAllShipsSunk(board);

            // Assert
            Assert.False(result);
        }
    }
}