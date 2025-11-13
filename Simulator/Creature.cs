namespace Simulator;

public class Creature
{
    private string name;
    private int level;

    // odczyt imienia
    public string Name
    {
        get { return name; }
    }

    // odczyt i walidacja przez set, wartości większe od zera, w przeciwnym razie default na 1
    public int Level
    {
        get { return level; }
        set { level = value > 0 ? value : 1; }
    }

    // konstruktor z wartościami automatycznymi
    public Creature(string name = "Unnamed Monstrosity", int level = 1)
    {
        this.name = name;
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
}
