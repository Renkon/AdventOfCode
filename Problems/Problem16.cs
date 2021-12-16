using System.Text;

namespace AdventOfCode.Problems
{
    public class Problem16 : IProblem<long, long>
    {
        public long DoPartA()
        {
            var binaryString = string.Join(
                string.Empty,
                Utils.InputToStringArray("16")
                    .First()
                    .Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            var versionSum = 0 as int?;

            ProcessPackage(binaryString, ref versionSum);

            return versionSum.Value;
        }


        public long DoPartB()
        {
            var binaryString = string.Join(
                string.Empty,
                Utils.InputToStringArray("16")
                    .First()
                    .Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            var dummy = null as int?;

            return ProcessPackage(binaryString, ref dummy).Item1;
        }

        // Returns a tuple with the literal value (optional) and the number of bits processed.
        private (long, int) ProcessPackage(string str, ref int? versionSum)
        {
            var version = Convert.ToInt32(str.Substring(0, 3), 2);
            var typeId = Convert.ToInt32(str.Substring(3, 3), 2);

            if (versionSum.HasValue)
            {
                versionSum += version;
            }

            // Literal case, only non switchable statement.
            if (typeId == 4)
            {
                var restOfString = str.Substring(6).ToCharArray();
                var shouldContinueProcessingGroups = true;
                var groupIndex = 0;
                var literalValue = new StringBuilder();

                while (shouldContinueProcessingGroups)
                {
                    shouldContinueProcessingGroups = restOfString[groupIndex] == '1';
                    literalValue.Append(restOfString[(groupIndex + 1)..(groupIndex + 5)]);
                    groupIndex += 5;
                }

                return (Convert.ToInt64(literalValue.ToString(), 2), groupIndex + 6);
            }

            // Logic to retrieve values.
            var values = new List<long>();

            // Parsing subpacket info
            var lengthTypeId = Convert.ToInt32(str.Substring(6, 1), 2);
            var processedBitsCount = 0;
            var typeIdBitSize = lengthTypeId == 0 ? 15 : 11;

            if (lengthTypeId == 0)
            {
                var bitsToProcess = Convert.ToInt32(str.Substring(7, 15), 2);

                while (bitsToProcess != processedBitsCount)
                {
                    var (value, bitsUsed) = ProcessPackage(
                        str.Substring(22 + processedBitsCount, bitsToProcess - processedBitsCount),
                        ref versionSum);
                    processedBitsCount += bitsUsed;
                    values.Add(value);
                }
                
            }
            else if (lengthTypeId == 1)
            {
                var numberOfSubpackets = Convert.ToInt32(str.Substring(7, 11), 2);

                for (int i = 0; i < numberOfSubpackets; i++)
                {
                    var (value, bitsUsed) = ProcessPackage(str.Substring(18 + processedBitsCount), ref versionSum);
                    processedBitsCount += bitsUsed;
                    values.Add(value);
                }
            }

            var totalBitsUsed = processedBitsCount + typeIdBitSize + 7;

            switch (typeId)
            {
                case 0:
                    return (values.Sum(), totalBitsUsed);
                case 1:
                    return (values.Aggregate(1L, (x, y) => x * y), totalBitsUsed);
                case 2:
                    return (values.Min(), totalBitsUsed);
                case 3:
                    return (values.Max(), totalBitsUsed);
                case 5:
                    return (values[0] > values[1] ? 1L : 0L, totalBitsUsed);
                case 6:
                    return (values[0] < values[1] ? 1L : 0L, totalBitsUsed);
                case 7:
                    return (values[0] == values[1] ? 1L : 0L, totalBitsUsed);
            }

            throw new Exception("Invalid typeId");
        }
    }
}
