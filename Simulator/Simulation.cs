namespace Simulator;

public class Simulation
{
    private int currentMoveIndex = 0;
    private List<string> moveList = new();

    public Map Map { get; }
    public List<Creature> Creatures { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;

    public Creature CurrentCreature => Creatures[currentMoveIndex % Creatures.Count];
    public string CurrentMoveName => moveList.Count == 0 ? "" : moveList[currentMoveIndex % moveList.Count].ToLower();

    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures ?? throw new ArgumentNullException(nameof(creatures));
        Positions = positions ?? throw new ArgumentNullException(nameof(positions));
        Moves = moves ?? "";

        if (Creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.");
        if (Creatures.Count != Positions.Count)
            throw new ArgumentException("Number of creatures must match number of positions.");

        // przypisanie stworów do mapy
        for (int i = 0; i < Creatures.Count; i++)
        {
            var creature = Creatures[i];
            var pos = Positions[i];
            creature.AssignMap(Map, pos);
        }

        moveList = new List<string>(Moves.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries));
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is already finished.");

        if (moveList.Count == 0)
        {
            Finished = true;
            return;
        }

        string moveName = CurrentMoveName;

        try
        {
            var directions = DirectionParser.Parse(moveName);
            foreach (var dir in directions)
            {
                CurrentCreature.Go(dir);
            }
        }
        catch { }

        currentMoveIndex++;
         
        if (currentMoveIndex >= moveList.Count)
        {
            Finished = true;
        }
    }
}
