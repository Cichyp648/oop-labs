namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }

    private readonly Rectangle bounds;

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size),
                "Map size must be between 5 and 20");

        Size = size;

        // obszar mapy (0,0)-(Size-1,Size-1)
        bounds = new Rectangle(0, 0, Size - 1, Size - 1);
    }

    public override bool Exist(Point p)
    {
        return bounds.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        var np = p.Next(d);
        return Exist(np) ? np : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var np = p.NextDiagonal(d);
        return Exist(np) ? np : p;
    }
}
