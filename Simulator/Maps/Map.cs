    namespace Simulator.Maps;

public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    private readonly Dictionary<Point, List<IMappable>> objects = new();

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeX > 20)
            throw new ArgumentOutOfRangeException(nameof(sizeX));
        if (sizeY < 5 || sizeY > 20)
            throw new ArgumentOutOfRangeException(nameof(sizeY));

        SizeX = sizeX;
        SizeY = sizeY;
    }

    public virtual bool Exist(Point p) =>
        p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;

    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);

    public void Add(IMappable obj, Point p)
    {
        if (!Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p));

        if (!objects.ContainsKey(p))
            objects[p] = new List<IMappable>();

        objects[p].Add(obj);
    }

    public void Remove(IMappable obj, Point p)
    {
        if (objects.ContainsKey(p))
            objects[p].Remove(obj);
    }

    public void Move(IMappable obj, Point from, Point to)
    {
        Remove(obj, from);
        Add(obj, to);
    }

    public List<IMappable> At(Point p) =>
        objects.ContainsKey(p)
            ? new List<IMappable>(objects[p])
            : new List<IMappable>();

    public List<IMappable> At(int x, int y) =>
        At(new Point(x, y));
}
