public class Ship
{
    public int Size { get; private set; }
    public int Hits { get; private set; }

    public Ship(int size)
    {
        Size = size;
        Hits = 0;
    }

    public void Hit()
    {
        Hits++;
    }

    public bool IsSunk()
    {
        return Hits >= Size;
    }
}