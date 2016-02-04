using System;
using Codility.BinaryGap;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryGap.Tests
{
    [TestClass]
    public class UnitTests
    {
        private int ToDecimal(string binaryInt)
        {
            return Convert.ToInt32(binaryInt, 2);
        }


        [TestMethod]
        public void Zero()
        {
            var n = new BinaryInteger(0);
            var result = n.MaxBinaryGap();
            result.Should().Be(0);
        }

        [TestMethod]
        public void MinValue()
        {
            var n = new BinaryInteger(int.MinValue);
            var result = n.MaxBinaryGap();
            result.Should().Be(0);
        }

        [TestMethod]
        public void MaxValue()
        {
            var n = new BinaryInteger(int.MaxValue);
            var result = n.MaxBinaryGap();
            result.Should().Be(0);
        }

        [TestMethod]
        public void NoGap()
        {
            var n = new BinaryInteger(3);
            var result = n.MaxBinaryGap();
            result.Should().Be(0);
        }

        [TestMethod]
        public void Gap1()
        {
            var n = new BinaryInteger(ToDecimal("1000101"));
            var result = n.MaxBinaryGap();
            result.Should().Be(3);
        }

        [TestMethod]
        public void Gap2()
        {
            var n = new BinaryInteger(ToDecimal("10100001"));
            var result = n.MaxBinaryGap();
            result.Should().Be(4);
        }

        [TestMethod]
        public void Gap3()
        {
            var n = new BinaryInteger(ToDecimal("1011111100000111"));
            var result = n.MaxBinaryGap();
            result.Should().Be(5);
        }

        [TestMethod]
        public void Gap4()
        {
            var n = new BinaryInteger(ToDecimal("11011100111000001110000000000"));
            var result = n.MaxBinaryGap();
            result.Should().Be(5);
        }

        [TestMethod]
        public void Gap5()
        {
            var n = new BinaryInteger(ToDecimal("110111001110000011100000000001"));
            var result = n.MaxBinaryGap();
            result.Should().Be(10);
        }

        [TestMethod]
        public void Gap6()
        {
            var n = new BinaryInteger(ToDecimal("0110111001110000011100000000001"));
            var result = n.MaxBinaryGap();
            result.Should().Be(10);
        }
    }
}