namespace AdventOfCode.Problems
{
    public class Problem6 : IProblem<long, long>
    {
        public long DoPartA()
        {
            var numbers = Utils.InputToStringArray("6").First().Split(",").Select(int.Parse);
            return PerformSimulation(numbers, 80);
        }

        public long DoPartB()
        {
            var numbers = Utils.InputToStringArray("6").First().Split(",").Select(int.Parse);
            return PerformSimulation(numbers, 256);
        }

        private long PerformSimulation(IEnumerable<int> startConditions, int days)
        {
            var daysCounter = new long[9];

            foreach (var number in startConditions)
            {
                daysCounter[number]++;
            }

            for (int i = 0; i < days; i++)
            {
                var lastDayCounters = daysCounter[0];

                for (int j = 0; j < daysCounter.Length - 1; j++)
                {
                    daysCounter[j] = daysCounter[j + 1];
                }

                daysCounter[6] += lastDayCounters;
                daysCounter[8] = lastDayCounters;
            }

            return daysCounter.Sum();
        }
    }
}
