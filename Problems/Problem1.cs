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
            int numberOfIncreases = 0;

            for (int i = 0; i < numbers.Count - stepSize; i++)
            {
                int sumPrevious = 0;
                int sumNext = 0;
                for (int j = 0; j < stepSize; j++)
                {
                    sumPrevious += numbers[i + j];
                    sumNext += numbers[i + j + 1];
                }

                if (sumPrevious < sumNext)
                {
                    numberOfIncreases++;
                }
            }

            return numberOfIncreases;
        }

        private IList<int> GetListOfIntegers()
        {
            return Utils.StringArrayToIntArray(Utils.InputToStringArray("1")).ToList();
        }
    }
}
