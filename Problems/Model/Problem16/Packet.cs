namespace AdventOfCode.Problems.Model.Problem16
{
    public abstract class Packet
    {
        public int Version { get; set; }
        
        public TypeId TypeId { get; set; }

        public long Value { get; set; }

        public int BitsCount { get; set; }

        public abstract int VersionSum { get; }

        public Packet(int version, TypeId typeId, string str)
        {
            Version = version;
            TypeId = typeId;
            ProcessPacketCreation(str);
        }

        protected abstract void ProcessPacketCreation(string str);

        public static Packet CreatePacketFrom(string str)
        {
            var version = Convert.ToInt32(str.Substring(0, 3), 2);
            var typeId = (TypeId) Convert.ToInt32(str.Substring(3, 3), 2);

            if (typeId == TypeId.LITERAL)
            {
                return new LiteralPacket(version, str.Substring(6));
            }

            var lengthTypeId = Convert.ToInt32(str.Substring(6, 1), 2);
            if (lengthTypeId == 0)
            {
                return new OperatorFixedBitLengthPacket(version, typeId, str.Substring(7));
            }
            else if (lengthTypeId == 1)
            {
                return new OperatorFixedCountPacket(version, typeId, str.Substring(7));
            }

            throw new Exception("Invalid packet");
        }
    }
}
