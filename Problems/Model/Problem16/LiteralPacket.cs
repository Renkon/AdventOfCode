using System.Text;

namespace AdventOfCode.Problems.Model.Problem16
{
    public class LiteralPacket : Packet
    {
        public override int VersionSum => Version;

        public LiteralPacket(int version, string str) : base(version, TypeId.LITERAL, str) 
        {
        }


        protected override void ProcessPacketCreation(string str)
        {
            var restOfString = str.ToCharArray();
            var shouldContinueProcessingGroups = true;
            var groupIndex = 0;
            var literalValue = new StringBuilder();

            while (shouldContinueProcessingGroups)
            {
                shouldContinueProcessingGroups = restOfString[groupIndex] == '1';
                literalValue.Append(restOfString[(groupIndex + 1)..(groupIndex + 5)]);
                groupIndex += 5;
            }

            Value = Convert.ToInt64(literalValue.ToString(), 2);
            BitsCount = groupIndex + 6;
        }
    }
}
