using System.Text;

namespace AdventOfCode.Problems.Model.Problem13
{
    public class Map
    {
        public IEnumerable<Point> Points { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Map(IEnumerable<Point> points)
        {
            Points = points;
            Width = Points.Select(p => p.X).Max() + 1;
            Height = Points.Select(p => p.Y).Max() + 1;
        }

        public Map Fold(string op)
        {
            var foldValue = int.Parse(op.Substring(2));

            if (op[0] is 'y')
            {
                return new Map(Points.Select(p => p.Y < foldValue ? p : p with { Y = 2 * foldValue - p.Y }).Distinct());
            }

            return new Map(Points.Select(p => p.X < foldValue ? p : p with { X = 2 * foldValue - p.X }).Distinct());
        }

        public string GetVisualization()
        {
            var sb = new StringBuilder();
            var map = new bool[Width, Height];

            foreach (var point in Points)
            {
                map[point.X, point.Y] = true;
            }

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    sb.Append(map[i, j] ? "#" : ".");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
