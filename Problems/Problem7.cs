﻿namespace AdventOfCode.Problems
{
    public class Problem7 : IProblem<long, long>
    {
        public long DoPartA()
        {
            var numbers = Utils.InputToStringArray("7").First().Split(",").Select(int.Parse);
            return GetOptimalDistance(numbers, (n1, n2) => Math.Abs(n1 - n2), n => n);
        }

        public long DoPartB()
        {
            var numbers = Utils.InputToStringArray("7").First().Split(",").Select(int.Parse);
            return GetOptimalDistance(numbers, (n1, n2) => Math.Abs(n1 - n2), n => (n * (n + 1)) / 2);
        }

        private long GetOptimalDistance(
            IEnumerable<int> numbers,
            Func<long, long, long> fnGen,
            Func<long, long> fnSum)
        {
            return Utils.GetRangeBetween(numbers.Min(), numbers.Max())
                .Select(n => numbers.Select(n2 => fnSum.Invoke(fnGen.Invoke(n2, n))).Sum())
                .Min();
        }
    }
}
