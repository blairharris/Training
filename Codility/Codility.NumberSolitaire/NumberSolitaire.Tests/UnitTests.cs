using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberSolitaire.Tests
{
    [TestClass]
    public class UnitTests
    {
        private readonly Solitaire _solitaire = new Solitaire();

        [TestMethod]
        public void TestExample()
        {
            int[] board = {1, -2, 0, 9, -1, -2};
            var result = _solitaire.MaxScore(board);
            result.Should().Be(8);
        }

        [TestMethod]
        public void Long1()
        {
            int[] board = { 1, -2, 0, 2, -1, -3, -4, -5, -6, -7, -8, -9, -10, -11, 1, 5, 10, -10 };
            var result = _solitaire.MaxScore(board);
            result.Should().Be(8);
        }

        [TestMethod]
        public void AllNegatives()
        {
            int[] board = { -1, -2, 0, -9, -1, -2 };
            var result = _solitaire.MaxScore(board);
            result.Should().Be(-3);
        }

        [TestMethod]
        public void AllZero()
        {
            int[] board = { 0, 0, 0, 0, 0, 0 };
            var result = _solitaire.MaxScore(board);
            result.Should().Be(0);
        }

        [TestMethod]
        public void AllPositive()
        {
            int[] board = { 1, 2, 3, 4, 10, 30 };
            var result = _solitaire.MaxScore(board);
            result.Should().Be(50);
        }

        [TestMethod]
        public void TwoSquares1()
        {
            int[] board = { 1, 2 };
            var result = _solitaire.MaxScore(board);
            result.Should().Be(3);
        }

        [TestMethod]
        public void TwoSquares2()
        {
            int[] board = { -1, -2 };
            var result = _solitaire.MaxScore(board);
            result.Should().Be(-3);
        }

        [TestMethod]
        public void TwoSquares3()
        {
            int[] board = { 1, -2 };
            var result = _solitaire.MaxScore(board);
            result.Should().Be(-1);
        }

    }
}
