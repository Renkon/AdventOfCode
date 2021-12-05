using AdventOfCode.Problems.Model.Problem5;

namespace AdventOfCode.Problems
{
    public class Problem5 : IProblem<long, long>
    {
        public long DoPartA() => ProcessWithMapConfig(true, true, false, 1);

        public long DoPartB() => ProcessWithMapConfig(true, true, true, 1);

        private long ProcessWithMapConfig(bool countHorizontals, bool countVerticals, bool countDiagonals, int moreThanValue)
        {
            var strs = Utils.InputToStringArray("5");
            var lines = strs.Select(x => x.Split(" -> ")).Select(s => (new Point(s[0]), new Point(s[1])));
            var xSize = lines.Select(line => Math.Max(line.Item1.X, line.Item2.X)).Max() + 1;
            var ySize = lines.Select(line => Math.Max(line.Item1.Y, line.Item2.Y)).Max() + 1;
            var map = new Map(countHorizontals, countVerticals, countDiagonals, xSize, ySize);

            foreach (var line in lines)
            {
                map.AddLine(line.Item1, line.Item2);
            }

            return map.GetPointsWithMoreThanNLines(moreThanValue);
        }
    }
}
