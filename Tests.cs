using AdventOfCode.Problems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [TestCategory(nameof(Utils))]
        public void TestDoAndMeasure()
        {
            var expectedValue = 42;
            var method = (Func<dynamic>)(() => expectedValue);
            var (result, ms) = Utils.DoAndMeasure(method);

            Assert.AreEqual(expectedValue, result);
            Assert.IsNotNull(ms);
        }

        [TestMethod]
        [TestCategory(nameof(Utils))]
        public void TestEmptyStringArrayToIntArray()
        {
            InnerTestStringArrayToIntArray(new List<string>(), new List<int>());
        }

        [TestMethod]
        [TestCategory(nameof(Utils))]
        public void TestNormalStringArrayToIntArray()
        {
            InnerTestStringArrayToIntArray(new List<string> { "1", "2", "3" }, new List<int> { 1, 2, 3 });
        }

        [TestMethod]
        [TestCategory(nameof(Utils))]
        public void TestStringArrayWithInvalidsToIntArray()
        {
            InnerTestStringArrayToIntArray(new List<string> { null!, "1", "2", "", "3" }, new List<int> { 1, 2, 3 });
        }

        [TestMethod]
        [TestCategory(nameof(Utils))]
        public void TestGetRangeBetweenWithNoInterval()
        {
            var range = Utils.GetRangeBetween(4, 4).ToList();
            CollectionAssert.AreEqual(new List<int> { 4 }, range);
        }

        [TestMethod]
        [TestCategory(nameof(Utils))]
        public void TestGetRangeBetweenWithInterval()
        {
            var range = Utils.GetRangeBetween(4, 8).ToList();
            CollectionAssert.AreEqual(new List<int> { 4, 5, 6, 7, 8 }, range);
        }

        [TestMethod]
        [TestCategory(nameof(Utils))]
        public void TestGetRangeBetweenWithReverseInterval()
        {
            var range = Utils.GetRangeBetween(8, 4).ToList();
            CollectionAssert.AreEqual(new List<int> { 8, 7, 6, 5, 4 }, range);
        }

        [TestMethod]
        [TestCategory(nameof(Utils))]
        public void TestInputToStringArray()
        {
            var expectedOut = new List<string> { "test", "load", "file" };
            var currentOut = Utils.InputToStringArray("0").ToList();
            CollectionAssert.AreEqual(expectedOut, currentOut);
        }

        private void InnerTestStringArrayToIntArray(List<string> inData, List<int> expectedOutData)
        {
            var outData = Utils.StringArrayToIntArray(inData).ToList();
            CollectionAssert.AreEqual(expectedOutData, outData);
        }

        [TestMethod]
        [TestCategory(nameof(Problem1))]
        public void TestProblem1PartA()
        {
            Assert.AreEqual(1665, new Problem1().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem1))]
        public void TestProblem1PartB()
        {
            Assert.AreEqual(1702, new Problem1().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem2))]
        public void TestProblem2PartA()
        {
            Assert.AreEqual(1250395, new Problem2().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem2))]
        public void TestProblem2PartB()
        {
            Assert.AreEqual(1451210346, new Problem2().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem3))]
        public void TestProblem3PartA()
        {
            Assert.AreEqual(2743844, new Problem3().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem3))]
        public void TestProblem3PartB()
        {
            Assert.AreEqual(6677951, new Problem3().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem4))]
        public void TestProblem4PartA()
        {
            Assert.AreEqual(23177, new Problem4().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem4))]
        public void TestProblem4PartB()
        {
            Assert.AreEqual(6804, new Problem4().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem5))]
        public void TestProblem5PartA()
        {
            Assert.AreEqual(7436, new Problem5().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem5))]
        public void TestProblem5PartB()
        {
            Assert.AreEqual(21104, new Problem5().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem6))]
        public void TestProblem6PartA()
        {
            Assert.AreEqual(345387, new Problem6().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem6))]
        public void TestProblem6PartB()
        {
            Assert.AreEqual(1574445493136, new Problem6().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem7))]
        public void TestProblem7PartA()
        {
            Assert.AreEqual(337833, new Problem7().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem7))]
        public void TestProblem7PartB()
        {
            Assert.AreEqual(96678050, new Problem7().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem8))]
        public void TestProblem8PartA()
        {
            Assert.AreEqual(521, new Problem8().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem8))]
        public void TestProblem8PartB()
        {
            Assert.AreEqual(1016804, new Problem8().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem9))]
        public void TestProblem9PartA()
        {
            Assert.AreEqual(524, new Problem9().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem9))]
        public void TestProblem9PartB()
        {
            Assert.AreEqual(1235430, new Problem9().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem10))]
        public void TestProblem10PartA()
        {
            Assert.AreEqual(193275, new Problem10().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem10))]
        public void TestProblem10PartB()
        {
            Assert.AreEqual(2429644557, new Problem10().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem11))]
        public void TestProblem11PartA()
        {
            Assert.AreEqual(1625, new Problem11().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem11))]
        public void TestProblem11PartB()
        {
            Assert.AreEqual(244, new Problem11().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem12))]
        public void TestProblem12PartA()
        {
            Assert.AreEqual(5333, new Problem12().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem12))]
        public void TestProblem12PartB()
        {
            Assert.AreEqual(146553, new Problem12().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem13))]
        public void TestProblem13PartA()
        {
            Assert.AreEqual(802, new Problem13().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem13))]
        public void TestProblem13PartB()
        {
            var expectedStr = "###..#..#.#..#.####.####..##..#..#.###." + Environment.NewLine +
                              "#..#.#.#..#..#.#.......#.#..#.#..#.#..#" + Environment.NewLine +
                              "#..#.##...####.###....#..#....#..#.###." + Environment.NewLine +
                              "###..#.#..#..#.#.....#...#.##.#..#.#..#" + Environment.NewLine +
                              "#.#..#.#..#..#.#....#....#..#.#..#.#..#" + Environment.NewLine +
                              "#..#.#..#.#..#.#....####..###..##..###." + Environment.NewLine;
            Assert.AreEqual(expectedStr, new Problem13().DoPartB());
        }

        [TestMethod]
        [TestCategory(nameof(Problem14))]
        public void TestProblem14PartA()
        {
            Assert.AreEqual(2321UL, new Problem14().DoPartA());
        }

        [TestMethod]
        [TestCategory(nameof(Problem14))]
        public void TestProblem14PartB()
        {
            Assert.AreEqual(2399822193707UL, new Problem14().DoPartB());
        }
    }
}
