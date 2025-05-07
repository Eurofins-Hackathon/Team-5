using System;

namespace Battleship
{
    public class Player
    {
        public string Name { get; private set; }
        public int Hits { get; private set; }
        public int Misses { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hits = 0;
            Misses = 0;
        }

        public void MakeMove(int x, int y)
        {
            // Logic for making a move on the game board
        }

        public void RecordHit()
        {
            Hits++;
        }

        public void RecordMiss()
        {
            Misses++;
        }
    }
}