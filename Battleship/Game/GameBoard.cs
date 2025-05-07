using System;

namespace Battleship
{
    public class GameBoard
    {
        private const int Size = 7;
        private char[,] board;

        public GameBoard()
        {
            board = new char[Size, Size];
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    board[i, j] = '~'; // Water
                }
            }
        }

        public void DisplayBoard(bool hideShips = false)
        {
            Console.WriteLine("  A B C D E F G");
            for (int i = 0; i < Size; i++)
            {
                Console.Write((i + 1) + " "); // Row numbers from 1 to 7
                for (int j = 0; j < Size; j++)
                {
                    if (hideShips && board[i, j] == 'S')
                    {
                        Console.Write("~ "); // Hide ships
                    }
                    else
                    {
                        Console.Write(board[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool PlaceShip(int x, int y)
        {
            if (IsValidPosition(x, y) && board[x, y] == '~')
            {
                board[x, y] = 'S'; // Ship
                return true;
            }
            return false;
        }

        public bool CheckHit(int x, int y)
        {
            if (IsValidPosition(x, y))
            {
                return board[x, y] == 'S';
            }
            return false;
        }

        public void MarkHit(int x, int y)
        {
            if (IsValidPosition(x, y) && board[x, y] == 'S')
            {
                board[x, y] = 'H'; // Hit
            }
        }

        public void MarkMiss(int x, int y)
        {
            if (IsValidPosition(x, y) && board[x, y] == '~')
            {
                board[x, y] = 'M'; // Miss
            }
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Size && y >= 0 && y < Size;
        }
        public char GetCell(int x, int y)
        {
            if (IsValidPosition(x, y))
            {
                return board[x, y];
            }
            throw new ArgumentOutOfRangeException("Invalid board position.");
        }
    }
}