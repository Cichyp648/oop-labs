using Simulator;
using Simulator.Maps;
using SimConsole;

namespace SimConsole
{
    internal class Program
    {
        static void Main()
        {
            SmallSquareMap map = new(5);
            List<Creature> creatures = new List<Creature>
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
    }
}
