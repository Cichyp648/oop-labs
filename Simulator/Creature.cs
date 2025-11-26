namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown"; // domyślne imie
    private int level = 1; // domyślny poziom 1

    // odczyt imienia
    public string Name
    {
        get { return name; }
        // walidacja imienia, init zamiast set - tylko jednorazowe ustalenie imienia
        init
        {
            string val = value.Trim(' ');

            if (val.Length < 3)
                val = val.PadRight(3, '#');

            if (val.Length > 25)
                val = val.Substring(0, 25).TrimEnd();

            if (val.Length < 3)
                val = val.PadRight(3, '#');

            if (char.IsLower(val[0]))
                val = char.ToUpper(val[0]) + val.Substring(1);

            name = val;
        }
    }

    // odczyt imienia
    public int Level
    {
        get { return level; }
        // walidacja przez init, ograniczenie do przedziału 1-10
        init
        {
            if (value < 1)
                level = 1;
            else if (value > 10)
                level = 10;
            else
                level = value;
        }
    }

    // konstruktor z wartościami automatycznymi
    public Creature(string name = "Unnamed Monstrosity", int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract void SayHi();

    // odczyt imienia i poziomu
    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
            Console.WriteLine($"Creature {Name} has been upgraded to level {Level}!");
        }
        else
            Console.WriteLine($"Creature {Name} cannot upgrade, level is already at the maximum!");
    }

    public void Go(Direction direction)
    {
        // odczytanie kierunku i zmiana na małą literę
        string currentDirection = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {currentDirection}");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
            Go(direction);
    }

    public void Go(string directions)
    {
        Direction[] dirs = DirectionParser.Parse(directions);
        Go(dirs);
    }

    public abstract int Power { get; }
}
public class Elf : Creature
{
    int agility, skillCounter;
    public int Agility
    {
        get { return agility; }
        init
        {
            if (value<0) agility = 0;
            else if (value>10) agility = 10;
            else agility = value;
        }
    }

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        if (Agility < 10)
        {
            skillCounter++;
            if (skillCounter == 3)
            {
                Console.WriteLine($"{Name} has leveled up his agility! His current level is {Agility}");
                skillCounter = 0;
            }
        }
    }

    public Elf() : base() { }
    public Elf(string name = "Unnamed Elf", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    public override int Power => 8 * Level + 2 * Agility;
}

public class Orc : Creature
{
    int rage, skillCounter;
    public int Rage
    {
        get { return rage; }
        init
        {
            if (value < 0) rage = 0;
            else if (value > 10) rage = 10;
            else rage = value;
        }
    }
    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        if (Rage < 10)
        {
            skillCounter++;
            if (skillCounter == 2)
            {
                Console.WriteLine($"{Name} has leveled up his rage! His current level is {Rage}");
                skillCounter = 0;
            }
        }
    }
    public Orc() { }
    public Orc(string name = "Unnamed Orc", int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    public override int Power => 7 * Level + 3 * Rage;
}