﻿using System.Text;

namespace AdventOfCode.Problems
{
    public class Problem3 : IProblem<long, long>
    {
        public long DoPartA()
        {
            var numbers = Utils.InputToStringArray("3");
            var gammaBuilder = new StringBuilder();
            var epsilonBuilder = new StringBuilder();

            foreach (var mapper in GetCountMappers(numbers))
            {
                gammaBuilder.Append(mapper.MaxBy(kv => kv.Count).Key);
                epsilonBuilder.Append(mapper.MinBy(kv => kv.Count).Key);
            }

            var gamma = gammaBuilder.ToString();
            var epsilon = epsilonBuilder.ToString();

            return Convert.ToInt32(gammaBuilder.ToString(), 2) * Convert.ToInt32(epsilonBuilder.ToString(), 2);
        }

        public long DoPartB()
        {
            var numbers = Utils.InputToStringArray("3");

            return Convert.ToInt32(ProcessAgregation(numbers, n => n.MaxBy(e => e.Count), ie => ie.OrderByDescending(e => e.Key)), 2)
                * Convert.ToInt32(ProcessAgregation(numbers, n => n.MinBy(e => e.Count), ie => ie.OrderBy(e => e.Key)), 2);
        }

        private IEnumerable<IEnumerable<(char Key, int Count)>> GetCountMappers(IEnumerable<string> numbers)
            => Enumerable.Range(0, numbers.First().Length)
                .Select(i => numbers.GroupBy(n => n[i])
                    .Select(g => (g.Key, g.Count())));

        private IEnumerable<IEnumerable<(char Key, int Count)>> GetCountMappers(
            IEnumerable<string> numbers,
            Func<IEnumerable<(char Key, int Count)>, IEnumerable<(char Key, int Count)>> orderingFn)
            => GetCountMappers(numbers).Select(n => orderingFn.Invoke(n));

        private string ProcessAgregation(
            IEnumerable<string> numbers,
            Func<IEnumerable<(char Key, int Count)>, (char Key, int Count)> aggregationCauseFn,
            Func<IEnumerable<(char Key, int Count)>, IEnumerable<(char Key, int Count)>> orderingFn)
            => Enumerable.Range(0, numbers.First().Length)
                .Aggregate(
                    numbers,
                    (nums, i) =>
                    {
                        var maxKey = aggregationCauseFn.Invoke(GetCountMappers(nums, orderingFn).ElementAt(i)).Key;
                        return nums.Where(n => n[i] == maxKey);
                    })
                .Single();
    }
}
