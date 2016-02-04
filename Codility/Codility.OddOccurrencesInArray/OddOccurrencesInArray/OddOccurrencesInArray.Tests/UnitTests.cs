using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OddOccurrencesInArray.Tests
{
    [TestClass]
    public class UnitTests
    {
        private readonly ArrayParser _parser = new ArrayParser();

        [TestMethod]
        public void Example()
        {
            int[] pairs = {9, 3, 9, 3, 9, 7, 9};
            var result = _parser.ValueOfUnpairedElement(pairs);
            result.Should().Be(7);
        }

        [TestMethod]
        public void OddFreqNotOne()
        {
            int[] pairs = {9, 3, 9, 3, 9, 7, 7, 7, 9};
            var result = _parser.ValueOfUnpairedElement(pairs);
            result.Should().Be(7);
        }

        [TestMethod]
        public void OddFreqIsFirstVal()
        {
            int[] pairs = {21, 9, 3, 9, 3, 9, 7, 7, 9};
            var result = _parser.ValueOfUnpairedElement(pairs);
            result.Should().Be(21);
        }

        [TestMethod]
        public void OddFreqIsLastVal()
        {
            int[] pairs = {9, 3, 9, 3, 9, 7, 7, 9, 21};
            var result = _parser.ValueOfUnpairedElement(pairs);
            result.Should().Be(21);
        }

        [TestMethod]
        public void MinValue()
        {
            int[] pairs = {9, 3, 9, 3, 9, int.MinValue, 9};
            var result = _parser.ValueOfUnpairedElement(pairs);
            result.Should().Be(int.MinValue);
        }

        [TestMethod]
        public void Zero()
        {
            int[] pairs = {9, 3, 9, 3, 9, 0, 9};
            var result = _parser.ValueOfUnpairedElement(pairs);
            result.Should().Be(0);
        }

        [TestMethod]
        public void MaxValue()
        {
            int[] pairs = {9, 3, 9, 3, 9, int.MaxValue, 9};
            var result = _parser.ValueOfUnpairedElement(pairs);
            result.Should().Be(int.MaxValue);
        }

        [TestMethod]
        public void AllPairs()
        {
            int[] pairs = { 9, 3, 9, 3, 9, 9 };
            Action a = () =>  _parser.ValueOfUnpairedElement(pairs);
            a.ShouldThrow<InvalidOperationException>();
        }
    }
}