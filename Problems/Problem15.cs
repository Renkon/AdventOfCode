using AdventOfCode.Problems.Model.Problem15;

namespace AdventOfCode.Problems
{
    public class Problem15 : IProblem<long, long>
    {
        public long DoPartA()
        {
            var entries = Utils.InputToStringArray("15")
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => s.ToCharArray().Select(c => c - '0').ToArray())
                .ToArray();


            return new AStar(entries).Solve();
        }

        public long DoPartB()
        {
            var entries = Utils.InputToStringArray("15")
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => s.ToCharArray().Select(c => c - '0').ToArray())
                .ToArray();

            return new AStar(RegenerateMatrix(entries, 5, 5)).Solve();
        }

        private int[][] RegenerateMatrix(int[][] entries, int multX, int multY)
        {
            var newEntries = CreateMatrixWithMultipliedSize(entries, multX, multY);

            for (int i = 0; i < entries.Length * 5; i++)
            {
                for (int j = 0; j < entries[0].Length * 5; j++)
                {
                    var val = entries[i % entries.Length][j % entries[0].Length] + i / entries.Length + j / entries[0].Length;
                    newEntries[i][j] = val <= 9 ? val : val % 9;
                }
            }

            return newEntries;
        }

        private int[][] CreateMatrixWithMultipliedSize(int[][] entries, int multX, int multY)
        {
            int[][] newEntries = new int[entries.Length * multX][];

            for (int i = 0; i < newEntries.Length; i++)
            {
                newEntries[i] = new int[entries[0].Length * multY];
            }

            return newEntries;
        }
    }
}
