using System;

namespace Battleship
{
    public class InputHandler
    {
        public string GetPlayerInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public (int, int) GetCoordinates(string prompt)
        {
            while (true)
            {
                string input = GetPlayerInput(prompt).ToUpper();
                if (input.Length == 2 &&
                    input[0] >= 'A' && input[0] <= 'G' &&
                    char.IsDigit(input[1]) &&
                    int.TryParse(input[1].ToString(), out int row) &&
                    row >= 1 && row <= 7)
                {
                    int x = row - 1; // Convert row to 0-based index
                    int y = input[0] - 'A'; // Convert column to 0-based index
                    return (x, y);
                }

                Console.WriteLine("Invalid input. Please enter coordinates in the format 'A1', 'B3', etc.");
            }
        }
    }
}