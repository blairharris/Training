using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PermMissingElement.Tests
{
    [TestClass]
    public class UnitTests
    {
        private readonly ContiguousIntArray _intArray = new ContiguousIntArray();

        [TestMethod]
        public void TestMethod1()
        {
            int[] input = {2, 3, 1, 5};
            var result = _intArray.MissingValue(input);
            result.Should().Be(4);
        }
    }
}