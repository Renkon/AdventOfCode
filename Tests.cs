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
            InnerTestStringArrayToIntArray(new List<string> { null, "1", "2", "", "3" }, new List<int> { 1, 2, 3 });
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
    }
}
