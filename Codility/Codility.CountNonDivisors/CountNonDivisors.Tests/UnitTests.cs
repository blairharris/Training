using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CountNonDivisors;

namespace CountNonDivisors.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void OneElement()
        {
            var algorothm = new NonDivisorsAlgorithm();

            int[] input = { 3 };
            int[] expectedOutput = { 0 };
            var result = algorothm.Calculate(input);
            result.ShouldBeEquivalentTo(expectedOutput);
        }


        [TestMethod]
        public void TestExample()
        {
            var algorothm = new NonDivisorsAlgorithm();

            int[] input = { 3,1,2,3,6};
            int[] expectedOutput = {2, 4, 3, 2, 0};
            var result = algorothm.Calculate(input);
            result.ShouldBeEquivalentTo(expectedOutput);
        }

        [TestMethod]
        public void TestCase1()
        {
            var algorothm = new NonDivisorsAlgorithm();

            int[] input = { 3, 4, 6, 7, 8, 9, 10, 12 };
            int[] expectedOutput = { 7, 7, 6, 7, 6, 6, 7, 4 };
            var result = algorothm.Calculate(input);
            result.ShouldBeEquivalentTo(expectedOutput);
        }
    }
}
