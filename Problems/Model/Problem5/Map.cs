namespace AdventOfCode.Problems.Model.Problem5
{
    public class Map
    {
        private readonly bool countHorizontals;
        private readonly bool countVerticals;
        private readonly bool countDiagonals;
        private readonly int[] mapFields;
        private readonly int width;
        private readonly int height;

        public Map(bool countHorizontals, bool countVerticals, bool countDiagonals, int xSize, int ySize)
        {
            this.countHorizontals = countHorizontals;
            this.countVerticals = countVerticals;
            this.countDiagonals = countDiagonals;
            mapFields = new int[xSize * ySize];
            width = xSize;
            height = ySize;
        }

        public void AddLine(Point from, Point to)
        {
            if (ShouldBeAdded(from, to))
            {
                Add(from.GetPointsBetween(to));
            }
        }

        public int GetPointsWithMoreThanNLines(int numberOfLines)
            => mapFields.Count(i => i > numberOfLines);

        private void Add(IEnumerable<Point> points)
        {
            foreach (var point in points)
            {
                mapFields[GetIndexFromPoint(point)]++;
            }
        }

        private int GetIndexFromPoint(Point point)
            => point.Y * width + point.X;

        private bool ShouldBeAdded(Point from, Point to)
            => (from.IsHorizontallyRelatedTo(to) && countHorizontals) ||
                (from.IsVerticallyRelatedTo(to) && countVerticals) ||
                (from.IsDiagonallyRelatedTo(to) && countDiagonals);
    }
}
