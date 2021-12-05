namespace AdventOfCode.Problems.Model.Problem5
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(string str)
        {
            var splitCoords = str.Split(",");
            X = int.Parse(splitCoords[0]);
            Y = int.Parse(splitCoords[1]);
        }

        public IEnumerable<Point> GetPointsBetween(Point otherPoint)
        {
            if (IsHorizontallyRelatedTo(otherPoint))
            {
                return Utils.GetRangeBetween(this.X, otherPoint.X)
                    .Select(n => new Point(n, this.Y));
            }
            else if (IsVerticallyRelatedTo(otherPoint))
            {
                return Utils.GetRangeBetween(this.Y, otherPoint.Y)
                    .Select(n => new Point(this.X, n));
            }
            else if (IsDiagonallyRelatedTo(otherPoint))
            {
                return Utils.GetRangeBetween(this.X, otherPoint.X)
                    .Zip(Utils.GetRangeBetween(this.Y, otherPoint.Y))
                    .Select(coords => new Point(coords.First, coords.Second));
            }

            return Enumerable.Empty<Point>();
        }

        public bool IsHorizontallyRelatedTo(Point otherPoint)
            => this.Y == otherPoint.Y;

        public bool IsVerticallyRelatedTo(Point otherPoint)
            => this.X == otherPoint.X;

        public bool IsDiagonallyRelatedTo(Point otherPoint)
            => Math.Abs(this.X - otherPoint.X) == Math.Abs(this.Y - otherPoint.Y);
    }
}
