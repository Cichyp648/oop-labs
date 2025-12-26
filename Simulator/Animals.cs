using Simulator;
using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unknown";

    public Map? Map { get; private set; }
    public Point? Position { get; protected set; }
    public virtual char Symbol => 'A';

    public string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public Animals() { }

    public Animals(string description)
    {
        Description = description;
    }

    public void AssignMap(Map map, Point p)
    {
        Map = map;
        Position = p;
        map.Add(this, p);
    }

    public virtual void Go(Direction direction)
    {
        if (Map == null || Position == null)
            return;

        var newPos = Map.Next(Position.Value, direction);
        Map.Move(this, Position.Value, newPos);
        Position = newPos;
    }
    
    public override string ToString()
    {
        string classInfo = GetType().Name.ToUpper();
        return $"{classInfo}: {Info}";
    }
}

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override char Symbol => CanFly ? 'B' : 'b';

    // ===== Constructors =====
    public Birds() : base() { }

    public Birds(string description, bool canFly = true)
        : base(description)
    {
        CanFly = canFly;
    }

    public override void Go(Direction direction)
    {
        if (Map == null || Position == null)
            return;

        Point newPos;

        if (CanFly)
        {
            // lot o dwa pola
            var temp = Map.Next(Position.Value, direction);
            newPos = Map.Next(temp, direction);
        }
        else
        {
            // nielot: ruch po skosie
            newPos = Map.NextDiagonal(Position.Value, direction);
        }

        Map.Move(this, Position.Value, newPos);
        Position = newPos;
    }

    public override string Info =>
        $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>";

    public override string ToString()
    {
        string classInfo = GetType().Name.ToUpper();
        return $"{classInfo}: {Info}";
    }
}