using System.Reflection.Emit;

namespace Simulator;
using Simulator.Maps;
using System.Linq.Expressions;

public abstract class Creature : IMappable

{
    private string name = "Unknown";
    private int level = 1;
    public virtual char Symbol => 'c';

    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public Map? Map { get; private set; } = null;
    public Point? Position { get; private set; } = null;

    public Creature(string name = "Unnamed Monstrosity", int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void AssignMap(Map map, Point p)
    {
        Map = map;
        Position = p;
        map.Add(this, p);
    }

    public void Go(Direction direction)
    {
        if (Map == null || Position == null)
            return;

        var newPos = Map.Next(Position.Value, direction);
        Map.Move(this, Position.Value, newPos);
        Position = newPos;
    }

    public void Go(Direction[] directions)
    {
        foreach (var dir in directions)
            Go(dir);
    }

    public void Go(string directions)
    {
        var dirs = DirectionParser.Parse(directions);
        Go(dirs);
    }

    public abstract void Greeting();
    public abstract string Info { get; }
    public abstract int Power { get; }

    public override string ToString() => $"{this.GetType().Name.ToUpper()}: {Info}";
}

public class Elf : Creature
{
    int agility, skillCounter;
    public override char Symbol => 'E';
    public int Agility
    {
        get => agility;
        // walidacja przeniesiona do Validator.Limiter
        set => agility = Validator.Limiter(value, 1, 10);
    }

    public void Sing()
    {
        if (Agility < 10)
        {
            skillCounter++;
            if (skillCounter == 3)
            {
                Agility++;
                skillCounter = 0;
            }
        }
    }

    public Elf() : base() { }
    public Elf(string name = "Unnamed Elf", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public override void Greeting() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    public override int Power => 8 * Level + 2 * Agility;
    public override string Info
    {
        get => $"{Name} [{Level}][{Agility}]";
    }
}

public class Orc : Creature
{
    int rage, skillCounter;
    public override char Symbol => 'O';
    public int Rage
    {
        get => rage;
        // walidacja przeniesiona do Validator.Limiter
        set => rage = Validator.Limiter(value, 1, 10);
    }
    public void Hunt()
    {
        if (Rage < 10)
        {
            skillCounter++;
            if (skillCounter == 2)
            {
                Rage++;
                skillCounter = 0;
            }
        }
    }
    public Orc() { }
    public Orc(string name = "Unnamed Orc", int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public override void Greeting() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    public override int Power => 7 * Level + 3 * Rage;
    public override string Info
    {
        get => $"{Name} [{Level}][{Rage}]";
    }
}
