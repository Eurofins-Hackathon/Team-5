using System;

namespace Battleship
{
   public class Program
    {
        static void Main(string[] args)
        {
            GameBoard humanBoard = new GameBoard();
            GameBoard computerBoard = new GameBoard();
            InputHandler inputHandler = new InputHandler();

            // Place ships for the computer randomly
            Random random = new Random();
            for (int i = 0; i < 5; i++) // Place 5 ships
            {
                int x, y;
                do
                {
                    x = random.Next(0, 7);
                    y = random.Next(0, 7);
                } while (!computerBoard.PlaceShip(x, y));
            }

            // Place ships for the human player
            Console.WriteLine("Place your 5 ships on the board.");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Placing ship {i + 1} of 5:");
                humanBoard.DisplayBoard();
                var (x, y) = inputHandler.GetCoordinates("Enter coordinates to place your ship (e.g., A1): ");
                while (!humanBoard.PlaceShip(x, y))
                {
                    Console.WriteLine("Invalid position or position already occupied. Try again.");
                    (x, y) = inputHandler.GetCoordinates("Enter coordinates to place your ship (e.g., A1): ");
                }
            }

            Console.WriteLine("All ships placed! Let the game begin.");
            Console.WriteLine("Your board:");
            humanBoard.DisplayBoard();

            // Game loop
            while (true)
            {
                // Human's turn
                Console.WriteLine("\nYour turn:");
                computerBoard.DisplayBoard(hideShips: true);
                var (x, y) = inputHandler.GetCoordinates("Enter coordinates to attack (e.g., A1): ");
                if (computerBoard.CheckHit(x, y))
                {
                    Console.WriteLine("You hit a ship!");
                    computerBoard.MarkHit(x, y);
                }
                else
                {
                    Console.WriteLine("You missed!");
                    computerBoard.MarkMiss(x, y);
                }

                // Check if human won
                if (IsAllShipsSunk(computerBoard))
                {
                    Console.WriteLine("Congratulations! You sank all the computer's ships!");
                    break;
                }

                // Computer's turn
                Console.WriteLine("\nComputer's turn:");
                do
                {
                    x = random.Next(0, 7);
                    y = random.Next(0, 7);
                } while (humanBoard.CheckHit(x, y) || !humanBoard.IsValidPosition(x, y));

                if (humanBoard.CheckHit(x, y))
                {
                    Console.WriteLine($"Computer hit your ship at {(char)(y + 'A')}{x + 1}!");
                    humanBoard.MarkHit(x, y);
                }
                else
                {
                    Console.WriteLine($"Computer missed at {(char)(y + 'A')}{x + 1}.");
                    humanBoard.MarkMiss(x, y);
                }

                // Check if computer won
                if (IsAllShipsSunk(humanBoard))
                {
                    Console.WriteLine("Game over! The computer sank all your ships!");
                    break;
                }

                // Display human's board
                Console.WriteLine("\nYour board:");
                humanBoard.DisplayBoard();
            }
        }

        public static bool IsAllShipsSunk(GameBoard board)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board.CheckHit(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
} 
