using System.Reflection.Emit;

namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown"; // domyślne imie
    private int level = 1; // domyślny poziom 1

    // odczyt imienia
    public string Name
    {
        get => name;
        // walidacja przeniesiona do Validator.Shortener
        init => name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => level;
        // walidacja przeniesiona do Validator.Limiter
        init => level = Validator.Limiter(value, 1, 10);
    }

    // konstruktor z wartościami automatycznymi
    public Creature(string name = "Unnamed Monstrosity", int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract void SayHi();

    // odczyt imienia i poziomu
    public abstract string Info { get; }
    
    public override string ToString()
    {
        string classInfo = this.GetType().Name.ToUpper();
        return $"{classInfo}: {Info}";
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
        get => agility;
        // walidacja przeniesiona do Validator.Limiter
        init => agility = Validator.Limiter(value, 1, 10);
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
    public override string Info
    {
        get => $"{Name} [{Level}][{Agility}]";
    }
}

public class Orc : Creature
{
    int rage, skillCounter;
    public int Rage
    {
        get => rage;
        // walidacja przeniesiona do Validator.Limiter
        init => rage = Validator.Limiter(value, 1, 10);
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
    public override string Info
    {
        get => $"{Name} [{Level}][{Rage}]";
    }
}
