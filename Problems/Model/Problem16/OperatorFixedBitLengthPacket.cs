namespace AdventOfCode.Problems.Model.Problem16
{
    public class OperatorFixedBitLengthPacket : OperatorPacket
    {
        public OperatorFixedBitLengthPacket(int version, TypeId typeId, string str) : base(version, typeId, str)
        {
        }

        protected override void ProcessPacketCreation(string str)
        {
            var processedBitsCount = 0;
            var bitsToProcess = Convert.ToInt32(str.Substring(0, 15), 2);

            while (bitsToProcess != processedBitsCount)
            {
                var childPacket = CreatePacketFrom(str.Substring(15 + processedBitsCount, bitsToProcess - processedBitsCount));
                processedBitsCount += childPacket.BitsCount;
                ChildPackets.Add(childPacket);
            }

            PerformOperation();
            BitsCount = processedBitsCount + 22;
        }
    }
}
