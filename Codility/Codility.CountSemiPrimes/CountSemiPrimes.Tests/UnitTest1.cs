using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Codility.CountSemiPrimes;

namespace CountSemiPrimes.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OneElementIsSemiPrime()
        {
            var counter = new SemiPrimeCounter();

            int[] p = {26};
            int[] q = {26};
            int[] expectedResult = {1};
            int[] result = counter.CountSemiPrimes(26, p, q);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void OneElementIsNotSemiPrime()
        {
            var counter = new SemiPrimeCounter();

            int[] p = { 27 };
            int[] q = { 27 };
            int[] expectedResult = { 0 };
            int[] result = counter.CountSemiPrimes(27, p, q);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void TestExample()
        {
            var counter = new SemiPrimeCounter();

            int[] p = { 1, 4, 16 };
            int[] q = { 26, 10, 20 };
            int[] expectedResult = { 10, 4, 0 };
            int[] result = counter.CountSemiPrimes(26, p, q);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void LargeArraySizes()
        {
            var counter = new SemiPrimeCounter();

            int[] p = Enumerable.Repeat(1, 50000).ToArray();
            int[] q = Enumerable.Repeat(26, 50000).ToArray();
            int[] expectedResult = Enumerable.Repeat(10, 50000).ToArray(); ;
            int[] result = counter.CountSemiPrimes(26, p, q);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void LargeArraySizesAndNumbers()
        {
            var counter = new SemiPrimeCounter();

            int[] p = Enumerable.Repeat(1000, 50000).ToArray();
            int[] q = Enumerable.Repeat(50000, 50000).ToArray();
            int[] expectedResult = Enumerable.Repeat(11811, 50000).ToArray(); ;
            int[] result = counter.CountSemiPrimes(50000, p, q);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
