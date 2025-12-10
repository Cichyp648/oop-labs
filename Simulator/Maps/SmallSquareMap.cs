using Simulator;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    private readonly Rectangle bounds;

    public SmallSquareMap(int size) : base(size, size)
    {
        bounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    public override bool Exist(Point p) => bounds.Contains(p);

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
