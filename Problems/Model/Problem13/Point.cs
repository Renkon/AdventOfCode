namespace AdventOfCode.Problems.Model.Problem13
{
    public record Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point(string str)
        {
            var strSplit = str.Split(",");
            X = int.Parse(strSplit[0]);
            Y = int.Parse(strSplit[1]);
        }
    }
}
