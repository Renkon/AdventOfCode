using AdventOfCode.Problems.Model.Problem13;

namespace AdventOfCode.Problems
{
    public class Problem13 : IProblem<long, string>
    {
        public long DoPartA()
        {
            var input = Utils.InputToStringArray("13")
                .Where(s => !string.IsNullOrEmpty(s));

            var foldOperations = input.Where(s => s.StartsWith("fold"))
                .Select(s => s.Replace("fold along ", ""));
            var points = input.Where(s => !s.StartsWith("fold"))
                .Select(s => new Point(s));
            var map = new Map(points);

            map = map.Fold(foldOperations.ElementAt(0));

            return map.Points.Count();
        }

        public string DoPartB()
        {
            var input = Utils.InputToStringArray("13")
                .Where(s => !string.IsNullOrEmpty(s));

            var foldOperations = input.Where(s => s.StartsWith("fold"))
                .Select(s => s.Replace("fold along ", ""));
            var points = input.Where(s => !s.StartsWith("fold"))
                .Select(s => new Point(s));
            var map = new Map(points);

            foreach (var fold in foldOperations)
            {
                map = map.Fold(fold); 
            }

            return map.GetVisualization();
        }
    }
}
