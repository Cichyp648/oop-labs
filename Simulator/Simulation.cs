using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    private int currentMoveIndex = 0;
    private readonly List<string> moveList = new();

    public Map Map { get; }
    public List<IMappable> Mappables { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;

    public IMappable CurrentMappable =>
        Mappables[currentMoveIndex % Mappables.Count];

    public string CurrentMoveName =>
        moveList.Count == 0
            ? ""
            : moveList[currentMoveIndex % moveList.Count].ToLower();

    private readonly Direction[] movesArray;

    public Simulation(
        Map map,
        List<IMappable> mappables,
        List<Point> positions,
        string moves)
    {
        Map = map ?? throw new ArgumentNullException(nameof(map));
        Mappables = mappables ?? throw new ArgumentNullException(nameof(mappables));
        Positions = positions ?? throw new ArgumentNullException(nameof(positions));
        Moves = moves ?? "";

        if (Mappables.Count == 0)
            throw new ArgumentException("Mappables list cannot be empty.");
        if (Mappables.Count != Positions.Count)
            throw new ArgumentException("Number of mappables must match number of positions.");

        movesArray = DirectionParser.Parse(Moves);
        currentMoveIndex = 0;

        for(int i = 0; i < Mappables.Count; i++)
        {
            Map.Add(Mappables[i], Positions[i]);
        }
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation finished.");

        if (currentMoveIndex >= movesArray.Length)
        {
            Finished = true;
            return;
        }

        int index = currentMoveIndex % Mappables.Count;

        IMappable obj = Mappables[index];
        Direction move = movesArray[currentMoveIndex];

        Point oldPos = Positions[index];
        Point newPos = oldPos.Next(move);

        obj.Go(move);

        Positions[index] = newPos;
        Map.Move(obj, oldPos, newPos);

        currentMoveIndex++;

        if (currentMoveIndex >= movesArray.Length)
            Finished = true;
    }
}
