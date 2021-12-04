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
    }
}
