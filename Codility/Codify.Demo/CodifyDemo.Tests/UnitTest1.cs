using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodilityDemoLib;
using FluentAssertions;

namespace CodilityDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExampleTest()
        {
            int[] array = {-1, 3, -4, 5, 1, -6, 2, 1};

            int result = Demo.Solution(array);
            result.Should().Be(1);
        }

        [TestMethod]
        public void ZeroOnly()
        {
            int[] array = { 0 };

            int result = Demo.Solution(array);
            result.Should().Be(0);
        }
        [TestMethod]
        public void TwoZeros()
        {
            int[] array = { 0, 0 };

            int result = Demo.Solution(array);
            result.Should().Be(0);
        }

        [TestMethod]
        public void IntMinValue()
        {
            int[] array = {0, int.MinValue, int.MinValue };

            int result = Demo.Solution(array);
            result.Should().Be(-1);
        }
        [TestMethod]
        public void IntMaxValue()
        {
            int[] array = { 0, int.MaxValue, int.MaxValue };

            int result = Demo.Solution(array);
            result.Should().Be(-1);
        }
        [TestMethod]
        public void IntMaxValueButTrueEqPoint1()
        {
            int[] array = { int.MaxValue, 0, int.MaxValue };

            int result = Demo.Solution(array);
            result.Should().Be(1);
        }
        [TestMethod]
        public void IntMaxValueButTrueEqPoint2()
        {
            int[] array = { -1, int.MaxValue, 0, -1, int.MaxValue };

            int result = Demo.Solution(array);
            result.Should().Be(2);
        }
        [TestMethod]
        public void IntMaxValueButTrueEqPoint3_Overflow()
        {
            int[] array = { 1, int.MaxValue, 0, 1, int.MaxValue };

            int result = Demo.Solution(array);
            result.Should().Be(-1);
        }
    }
}
