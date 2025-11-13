namespace Simulator;

public class Creature
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

    public void SayHi()
    {
        Console.WriteLine($"Hi! They call me the {Name} and i'm on level {Level}!");
    }

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
}
