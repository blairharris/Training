using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MaxCounters;

namespace MaxCounters.Tests
{
    [TestClass]
    public class UnitTests
    {
        private readonly Counters _counters = new Counters();


        [TestMethod]
        public void TestExample()
        {
            int[] operations = {3, 4, 4, 6, 1, 4, 4};
            int[] expectedOutput = { 3, 2, 2, 4, 2 };

            int[] c = _counters.Operate(5, operations);
            c.Should().BeEquivalentTo(expectedOutput);
        }

        [TestMethod]
        public void OperationEdgeCases()
        {
            int[] operations = { 3, 4, 4, 6, 1, 5, 4 };
            int[] expectedOutput = { 3, 2, 2, 3, 3 };

            int[] c = _counters.Operate(5, operations);
            c.Should().BeEquivalentTo(expectedOutput);
        }





        [TestMethod]
        public void SingleCounterAndOperationInc()
        {
            int[] operations = { 1 };
            int[] expectedOutput = { 1 };

            int[] c = _counters.Operate(1, operations);
            c.Should().BeEquivalentTo(expectedOutput);
        }

        [TestMethod]
        public void SingleCounterAndOperationMax()
        {
            int[] operations = { 2 };
            int[] expectedOutput = { 0 };

            int[] c = _counters.Operate(1, operations);
            c.Should().BeEquivalentTo(expectedOutput);
        }

        [TestMethod]
        public void SingleCounter()
        {
            int[] operations = { 1, 1, 2, 1 };
            int[] expectedOutput = { 3 };

            int[] c = _counters.Operate(1, operations);
            c.Should().BeEquivalentTo(expectedOutput);
        }

        [TestMethod]
        public void SingleOperationInc()
        {
            int[] operations = { 3 };
            int[] expectedOutput = { 0, 0, 1, 0, 0 };

            int[] c = _counters.Operate(5, operations);
            c.Should().BeEquivalentTo(expectedOutput);
        }

        [TestMethod]
        public void LargeNumberofCounters()
        {
            var random = new Random();
            int[] operations = new int[100000];
            for (var i = 0; i < 100000; i++)
                operations[i] = random.Next(1, 100000);

            int[] expectedOutput = { 0, 0, 1, 0, 0 };

            int[] c = _counters.Operate(100000, operations);
            c[0].Should().BeGreaterOrEqualTo(0);
        }

    }
}
