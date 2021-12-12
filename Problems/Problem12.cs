namespace AdventOfCode.Problems
{
    public class Problem12 : IProblem<long, long>
    {
        public long DoPartA()
        {
            var entries = Utils.InputToStringArray("12")
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => s.Split("-"))
                .Select(s => (s[0], s[1]));
            entries = entries.Concat(entries.Select(s => (s.Item2, s.Item1)));

            var entriesDict = entries.Select(s => s.Item1).Concat(entries.Select(s => s.Item2)).Distinct().ToDictionary(e => e, e => 0);
            return Pathfind("start", "end", entries, entriesDict);
        }

        public long DoPartB()
        {
            var entries = Utils.InputToStringArray("12")
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => s.Split("-"))
                .Select(s => (s[0], s[1]));
            entries = entries.Concat(entries.Select(s => (s.Item2, s.Item1)));

            var entriesDict = entries.Select(s => s.Item1).Concat(entries.Select(s => s.Item2)).Distinct().ToDictionary(e => e, e => 0);
            return Pathfind("start", "end", entries, entriesDict, false);
        }

        private long Pathfind(string init, string end, IEnumerable<(string, string)> relations, Dictionary<string, int> entriesDict, bool? visitOneTwice = null)
        {
            if (init == end)
            {
                return 1L;
            }
            
            entriesDict[init]++;
            var pathCount = 0L;
            var isFirstSecondVisit = false;

            var whereFilter = default(Func<(string, string), bool>);
            var pathFindFunc = default(Func<string, string, IEnumerable<(string, string)>, Dictionary<string, int>, bool?, bool, long>);

            if (visitOneTwice.HasValue)
            {
                whereFilter = i => i.Item1 == init && ((_, isFirstSecondVisit) = CanVisit(i.Item2, entriesDict, visitOneTwice.Value)).Item1;
                pathFindFunc = (i, e, r, eD, b, i2v) => Pathfind(i, e, r, new Dictionary<string, int>(eD), b.Value || i2v);
            }
            else
            {
                whereFilter = i => i.Item1 == init && CanVisit(i.Item2, entriesDict);
                pathFindFunc = (i, e, r, eD, b, i2v) => Pathfind(i, e, r, new Dictionary<string, int>(eD));
            }

            foreach (var relation in relations.Where(whereFilter))
            {
                pathCount += pathFindFunc.Invoke(relation.Item2, end, relations, entriesDict, visitOneTwice, isFirstSecondVisit);
            }

            return pathCount;
        }

        private bool CanVisit(string where, Dictionary<string, int> entriesDict)
            => where.ToUpper() == where || entriesDict[where] < 1;

        private (bool, bool) CanVisit(string where, Dictionary<string, int> entriesDict, bool visitedOneTwice)
        {
            if (where.ToUpper() == where || entriesDict[where] < 1)
            {
                return (true, false);
            }

            if (entriesDict[where] < 2 && !visitedOneTwice && !new[] { "start", "end" }.Contains(where))
            {
                return (true, true);
            }

            return (false, false);
        }
    }
}
