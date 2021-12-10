using System.Numerics;

namespace AdventOfCode.Problems
{
    public class Problem10 : IProblem<long, long>
    {
        public long DoPartA()
        {
            var entries = Utils.InputToStringArray("10").Where(s => !string.IsNullOrEmpty(s));
            var pointsCounter = 0L;

            foreach (var str in entries)
            {
                var stack = new Stack<char>();

                foreach (var c in str)
                {
                    if (isOpener(c))
                    {
                        stack.Push(c);
                    }
                    else if (GetReverseCharacter(c) != stack.Pop())
                    {
                        pointsCounter += GetPointsForNotClosedCharacter(c);
                        break;
                    }
                }
            }

            return pointsCounter;
        }

        public long DoPartB()
        {
            var entries = Utils.InputToStringArray("10").Where(s => !string.IsNullOrEmpty(s));
            var pointsList = new List<long>();

            foreach (var str in entries)
            {
                var stack = new Stack<char>();
                var error = false;

                foreach (var c in str)
                {
                    if (isOpener(c))
                    {
                        stack.Push(c);
                    }
                    else if (GetReverseCharacter(c) != stack.Pop())
                    {
                        error = true;
                        break;
                    }
                }

                if (!error && stack.Count() > 0)
                {
                    var pointsCounter = 0L;

                    while (stack.Count() != 0)
                    {
                        pointsCounter = pointsCounter * 5 + GetPointsForWrongClosingCharacter(stack.Pop());
                    }

                    pointsList.Add(pointsCounter);
                }
            }

            return pointsList.OrderBy(x => x).ElementAt(pointsList.Count() / 2);
        }

        private bool isOpener(char c)
            => new[] {'(', '[', '{', '<' }.Contains(c);

        private char GetReverseCharacter(char c)
        {
            switch (c)
            {
                case ')':
                    return (char)(c - 1);
                default:
                    return (char)(c - 2);
            }
        }

        private long GetPointsForWrongClosingCharacter(char c)
        {
            switch (c)
            {
                case '(':
                    return 1L;
                case '[':
                    return 2L;
                case '{':
                    return 3L;
                case '<':
                    return 4L;
            }

            return -1;
        }

        private long GetPointsForNotClosedCharacter(char c)
        {
            switch (c)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;
            }

            return -1;
        }
    }
}
