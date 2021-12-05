using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode
{
    public static class Utils
    {
        public static IEnumerable<string> InputToStringArray(string inputName)
        {
            var path = $"{Directory.GetParent(Assembly.GetExecutingAssembly().Location)}/Inputs/{inputName}.txt";
            return File.ReadAllLines(path);
        }

        public static IEnumerable<int> StringArrayToIntArray(IEnumerable<string> strArray)
            => strArray.Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse);

        public static (dynamic, long) DoAndMeasure(Func<dynamic> func)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = func.Invoke();
            stopwatch.Stop();

            return (result, stopwatch.ElapsedMilliseconds);
        }

        public static IEnumerable<int> GetRangeBetween(int start, int end)
        {
            if (start <= end)
            {
                return Enumerable.Range(start, end - start + 1);
            }

            return Enumerable.Range(end, start - end + 1).Reverse();
        }
    }
}
