namespace AdventOfCode.Problems
{
    public class Problem1 : IProblem<int, int>
    {

        public int DoPartA()
        {
            return CountIncreasesByStep(GetListOfIntegers(), 1);
        }

        public int DoPartB()
        {
            return CountIncreasesByStep(GetListOfIntegers(), 3);
        }

        private int CountIncreasesByStep(IList<int> numbers, int stepSize)
        {
            return numbers.Take(new Range(0, numbers.Count - stepSize))
                .Select((n, i) => n - numbers[i + stepSize])
                .Count(n => n < 0);
        }

        private IList<int> GetListOfIntegers()
        {
            return Utils.StringArrayToIntArray(Utils.InputToStringArray("1")).ToList();
        }
    }
}
