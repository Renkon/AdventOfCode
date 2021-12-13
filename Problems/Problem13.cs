using AdventOfCode.Problems.Model.Problem13;

namespace AdventOfCode.Problems
{
    public class Problem13 : IProblem<long, string>
    {
        public long DoPartA()
        {
            var (map, foldOperations) = GenerateMapAndOperations();

            map = map.Fold(foldOperations.ElementAt(0));

            return map.Points.Count();
        }

        public string DoPartB()
        {
            var (map, foldOperations) = GenerateMapAndOperations();

            foreach (var fold in foldOperations)
            {
                map = map.Fold(fold); 
            }

            return map.GetVisualization();
        }

        private (Map, IEnumerable<string>)  GenerateMapAndOperations()
        {
            var input = Utils.InputToStringArray("13")
                .Where(s => !string.IsNullOrEmpty(s));

            var foldOperations = input.Where(s => s.StartsWith("fold"))
                .Select(s => s.Replace("fold along ", ""));
            var points = input.Where(s => !s.StartsWith("fold"))
                .Select(s => new Point(s));

            return (new Map(points), foldOperations);
        }
    }
}
