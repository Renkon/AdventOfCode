using System.Text;

namespace AdventOfCode.Problems
{
    public class Problem14 : IProblem<ulong, ulong>
    {
        public ulong DoPartA()
            => DoSteps(10);

        public ulong DoPartB()
            => DoSteps(40);

        private ulong DoSteps(int steps)
        {
            var entries = Utils.InputToStringArray("14").Where(s => !string.IsNullOrEmpty(s));
            var template = entries.First();
            var rules = entries.Skip(1).ToDictionary(s => s.Substring(0, 2), s => s.Substring(6));

            var countMap = PerformSimulation(steps, template, rules);
            return countMap.Max() - countMap.Min();
        }

        private IEnumerable<ulong> PerformSimulation(int steps, string template, Dictionary<string, string> rules)
            => GetCharacterCount(ProcessSteps(steps, template, rules));

        private IEnumerable<ulong> GetCharacterCount(Dictionary<string, ulong> dictMap)
        {
            var charMap = new Dictionary<char, ulong>();

            foreach (var kv in dictMap)
            {
                Increment(charMap, kv.Key[0], kv.Value);
                Increment(charMap, kv.Key[1], kv.Value);
            }

            return charMap.Select(kv => (ulong) Math.Ceiling(kv.Value / 2.0));
        }

        private Dictionary<string, ulong> ProcessSteps(int steps, string template, Dictionary<string, string> rules)
        {
            var dictMap = InitializeDictMap(template);

            for (int s = 0; s < steps; s++)
            {
                var newDictMap = new Dictionary<string, ulong>();
                foreach (var entry in dictMap)
                {
                    var key = entry.Key;
                    Increment(newDictMap, $"{key[0]}{rules[key]}", entry.Value);
                    Increment(newDictMap, $"{rules[key]}{key[1]}", entry.Value);
                }

                dictMap = newDictMap;
            }

            return dictMap;
        }

        private Dictionary<string, ulong> InitializeDictMap(string template)
        {
            var dict = new Dictionary<string, ulong>();

            for (int i = 0; i < template.Length - 1; i++)
            {
                var key = $"{template[i]}{template[i + 1]}";
                Increment(dict, key);
            }

            return dict;
        }

        private void Increment<U>(Dictionary<U, ulong> dict, U key, ulong increment = 1)
            => dict[key] = dict.GetValueOrDefault(key, 0UL) + increment;
    }
}
