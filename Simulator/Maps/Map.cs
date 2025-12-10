using Simulator;
using System.Collections.Generic;

public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    private readonly Dictionary<Point, List<Creature>> creatures = new();

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeX > 20)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Width must be between 5 and 20.");
        if (sizeY < 5 || sizeY > 20)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Height must be between 5 and 20.");

        SizeX = sizeX;
        SizeY = sizeY;
    }

    public virtual bool Exist(Point p) => p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;

    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);

    public void Add(Creature creature, Point p)
    {
        if (!Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p), "Point outside map bounds.");

        if (!creatures.ContainsKey(p))
            creatures[p] = new List<Creature>();

        creatures[p].Add(creature);
    }

    public void Remove(Creature creature, Point p)
    {
        if (creatures.ContainsKey(p))
            creatures[p].Remove(creature);
    }

    public void Move(Creature creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }

    public List<Creature> At(Point p) =>
        creatures.ContainsKey(p) ? new List<Creature>(creatures[p]) : new List<Creature>();

    public List<Creature> At(int x, int y) => At(new Point(x, y));
}
