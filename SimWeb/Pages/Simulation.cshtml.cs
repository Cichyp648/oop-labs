using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    public List<string> History { get; private set; } = new();

    public void OnGet()
    {
        var map = new SmallSquareMap(10);

        var mappables = new List<IMappable>
        {
            new Orc("Gorg"),
            new Elf("Elandor")
        };

        var positions = new List<Point>
        {
            new Point(2, 2),
            new Point(5, 5)
        };

        string moves = "URRDLU";

        var simulation = new Simulation(
            map,
            mappables,
            positions,
            moves
        );

        while (!simulation.Finished)
        {
            simulation.Turn();
        }

        History = simulation.History;
    }
}
