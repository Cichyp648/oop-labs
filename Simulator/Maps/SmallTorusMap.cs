using System;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size),
                "Map size must be between 5 and 20.");
        Size = size;
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size &&
               p.Y >= 0 && p.Y < Size;
    }

    public override Point Next(Point p, Direction d)
    {
        int x = p.X;
        int y = p.Y;

        switch (d)
        {
            case Direction.Up: y = (y + 1) % Size; break;
            case Direction.Down: y = (y - 1 + Size) % Size; break;
            case Direction.Left: x = (x - 1 + Size) % Size; break;
            case Direction.Right: x = (x + 1) % Size; break;
        }

        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        int x = p.X;
        int y = p.Y;

        switch (d)
        {
            case Direction.Up: x = (x + 1) % Size; y = (y + 1) % Size; break;
            case Direction.Right: x = (x + 1) % Size; y = (y - 1 + Size) % Size; break;
            case Direction.Down: x = (x - 1 + Size) % Size; y = (y - 1 + Size) % Size; break;
            case Direction.Left: x = (x - 1 + Size) % Size; y = (y + 1) % Size; break;
        }

        return new Point(x, y);
    }
}
