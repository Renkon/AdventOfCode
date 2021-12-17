using AdventOfCode.Problems.Model.Problem16;

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

            return Packet.CreatePacketFrom(binaryString).VersionSum;
        }


        public long DoPartB()
        {
            var binaryString = string.Join(
                string.Empty,
                Utils.InputToStringArray("16")
                    .First()
                    .Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            return Packet.CreatePacketFrom(binaryString).Value;
        }
    }
}
