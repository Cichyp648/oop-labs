namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string input)
    {
        // tablica wynikowa może byćinnego rozmiaru, dlatego wykorzystuję listę,
        // która nie ma stałego rozmiaru
        List<Direction> directions = new List<Direction>();

        foreach (char c in input.ToUpper()) // niezależna wielkość liter wejściowych
        {
            switch (c)
            {
                case 'U':
                    directions.Add(Direction.Up);
                    break;
                case 'R':
                    directions.Add(Direction.Right);
                    break;
                case 'D':
                    directions.Add(Direction.Down);
                    break;
                case 'L':
                    directions.Add(Direction.Left);
                    break;
            }
        }

        return directions.ToArray();
    }
}