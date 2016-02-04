using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TapeEquilibrium.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Calculator calculator = new Calculator();


        [TestMethod]
        public void ExerciseExample()
        {
            int[] a = { 3, 1, 2, 4, 3 };
            var result = calculator.MinDifference(a);
            result.Should().Be(1);
        }

        [TestMethod]
        public void Eg2()
        {
            int[] a = { 1, 2, 3, 4, 5 };
            var result = calculator.MinDifference(a);
            result.Should().Be(3);
        }

        [TestMethod]
        public void TwoElements()
        {
            int[] a = { 1000, -1000 };
            var result = calculator.MinDifference(a);
            result.Should().Be(2000);
        }
    }
}
