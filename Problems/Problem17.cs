namespace AdventOfCode.Problems
{
    public class Problem17 : IProblem<long, long>
    {
        public long DoPartA() => Do(list => list.Max(x => x.Result.MaxY));

        public long DoPartB() => Do(list => list.Count());

        public long Do(Func<List<(int X, int Y, (int MaxY, bool DidLand) Result)>, long> lambda)
        {
            var targetCoords = Utils.InputToStringArray("17")
                .First()
                .Split(", ")
                .Select(s => s.Split("=").Last().Split("..").Select(int.Parse))
                .Select(sa => Utils.GetRangeBetween(sa.ElementAt(0), sa.ElementAt(1)));

            var minX = targetCoords.ElementAt(0).Min();
            var maxX = targetCoords.ElementAt(0).Max();
            var minY = targetCoords.ElementAt(1).Min();
            var maxY = targetCoords.ElementAt(1).Max();

            return lambda.Invoke(GetLandingTrajectories((minX, maxX, minY, maxY)));
        }

        private List<(int X, int Y, (int MaxY, bool DidLand) Result)> GetLandingTrajectories((int MinXB, int MaxXB, int MinYB, int MaxYB) bounds)
        {

            List<(int X, int Y, (int MaxY, bool DidLand) Result)> fires = new();
            Enumerable.Range(0, 1000).ToList().ForEach(x =>
            {
                Enumerable.Range(-1000, 2000).ToList().ForEach(y =>
                {
                    fires.Add((x, y, Fire(x, y, bounds)));
                });
            });
            return fires.Where(x => x.Result.DidLand).ToList();
        }

        public (int MaxY, bool DidLand) Fire(int xVelocity, int yVelocity, (int MinXB, int MaxXB, int MinYB, int MaxYB) bounds)
        {
            var current = (X: 0, Y: 0);
            var maxY = 0;

            while (true)
            {
                current.X += xVelocity;
                current.Y += yVelocity;

                xVelocity = Math.Max(0, xVelocity - 1);
                yVelocity--;
                maxY = Math.Max(maxY, current.Y);

                if (current.X >= bounds.MinXB && current.X <= bounds.MaxXB && current.Y >= bounds.MinYB && current.Y <= bounds.MaxYB)
                {
                    return (maxY, true);
                }

                if (current.X > bounds.MaxXB || current.Y < bounds.MinYB)
                {
                    return (maxY, false);
                }
            }
        }
    }
}
