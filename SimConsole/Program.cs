using Simulator;
using Simulator.Maps;
using SimConsole;
namespace SimConsole;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Select simulation:");
        Console.WriteLine("1 - Creatures");
        Console.WriteLine("2 - Animals");
        Console.WriteLine("3 - History");

        var selection = Console.ReadKey().KeyChar;
        Console.Clear();

        switch (selection)
        {
            case '1':
                Sim1();
                break;

            case '2':
                Sim2();
                break;
            case '3':
                Sim3();
                break;
        }
    }

    static void Sim1()
    {
        SmallSquareMap map = new(5);
        List<IMappable> creatures = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor")
        };
        List<Point> points = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1)
        };
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        mapVisualizer.Draw();

        Console.WriteLine("\n--- Simulating moves ---\n");

        while (!simulation.Finished)
        {
            Console.Clear(); // czyszczenie, żeby była "animacja" - konsola troche miga ale działa
            simulation.Turn();
            mapVisualizer.Draw();
            System.Threading.Thread.Sleep(1000); // sekunda przerwy
            Console.WriteLine();
        }

        Console.WriteLine("Simulation finished.");
    }

    static void Sim2()
    {
        var map = new SmallTorusMap(8, 6);

        List<IMappable> objects = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals("Rabbits"),
            new Birds("Eagles", true),
            new Birds("Ostriches", false),
        };

                List<Point> positions = new()
        {
            new(1,1),
            new(2,2),
            new(3,3),
            new(4,3),
            new(5,2)
        };

        string moves = "uldruldruldruldruldr";

        var sim = new Simulation(map, objects, positions, moves);
        var vis = new MapVisualizer(sim.Map);

        while (!sim.Finished)
        {
            Console.Clear();
            sim.Turn();
            vis.Draw();
            Thread.Sleep(500);
        }
    }

    static void Sim3()
    {
        var map = new SmallTorusMap(8, 6);

        List<IMappable> objects = new()
    {
        new Elf("Elandor"),
        new Orc("Gorbag"),
        new Animals("Rabbits"),
        new Birds("Eagles", true),
        new Birds("Ostriches", false),
    };

        List<Point> positions = new()
    {
        new(1,1),
        new(2,2),
        new(3,3),
        new(4,3),
        new(5,2)
    };

        string moves = "uldruldruldruldruldr";

        var simulation = new Simulation(map, objects, positions, moves);

        var log = new SimulationLog(simulation);
        var visualizer = new LogVisualizer(log);

        foreach (var turn in new[] { 5, 10, 15, 20 })
        {
            visualizer.Draw(turn);
            Console.ReadKey();
        }
    }
    
}
