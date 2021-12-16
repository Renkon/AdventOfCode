namespace AdventOfCode.Problems.Model.Problem16
{
    public class OperatorFixedCountPacket : OperatorPacket
    {
        public OperatorFixedCountPacket(int version, TypeId typeId, string str) : base(version, typeId, str)
        {
        }

        protected override void ProcessPacketCreation(string str)
        {
            var processedBitsCount = 0;
            var numberOfSubpackets = Convert.ToInt32(str.Substring(0, 11), 2);

            for (int i = 0; i < numberOfSubpackets; i++)
            {
                var packet = CreatePacketFrom(str.Substring(11 + processedBitsCount));
                processedBitsCount += packet.BitsCount;
                ChildPackets.Add(packet);
            }

            PerformOperation();
            BitsCount = processedBitsCount + 18;
        }
    }
}
