namespace AdventOfCode.Problems.Model.Problem16
{
    public abstract class OperatorPacket : Packet
    {
        public override int VersionSum => ChildPackets.Select(p => p.VersionSum).DefaultIfEmpty(0).Sum() + Version;

        protected List<Packet> ChildPackets = new List<Packet>();

        public OperatorPacket(int version, TypeId typeId, string str) : base(version, typeId, str)
        {
        }

        public void PerformOperation()
        {
            Value = TypeIdFunctors[TypeId].Invoke(ChildPackets.Select(p => p.Value));
        }

        private static Dictionary<TypeId, Func<IEnumerable<long>, long>> TypeIdFunctors =
            new Dictionary<TypeId, Func<IEnumerable<long>, long>>
            {
                [TypeId.SUM] = list => list.Sum(),
                [TypeId.PRODUCT] = list => list.Aggregate(1L, (x, y) => x * y),
                [TypeId.MINIMUM] = list => list.Min(),
                [TypeId.MAXIMUM] = list => list.Max(),
                [TypeId.GREATERTHAN] = list => list.ElementAt(0) > list.ElementAt(1) ? 1L : 0L,
                [TypeId.LESSTHAN] = list => list.ElementAt(0) < list.ElementAt(1) ? 1L : 0L,
                [TypeId.EQUALTO] = list => list.ElementAt(0) == list.ElementAt(1) ? 1L : 0L,
            };
    }
}
