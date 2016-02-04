using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxNonOverlappingSegments.Tests
{
    [TestClass]
    public class UnitTests
    {
        private readonly SegmentAnalyser _analyser = new SegmentAnalyser();

        [TestMethod]
        public void TestExample()
        {
            int[] leftEndPts = {1, 3, 7, 9, 9};
            int[] rightEndPts = {5, 6, 8, 9, 10};

            var result = _analyser.MaxNonOverlappingSetSize(leftEndPts, rightEndPts);
            result.Should().Be(3);
        }

        [TestMethod]
        public void TestMethod1()
        {
            int[] leftEndPts = {1, 3, 6, 7, 9, 9};
            int[] rightEndPts = {5, 6, 6, 8, 9, 10};

            var result = _analyser.MaxNonOverlappingSetSize(leftEndPts, rightEndPts);
            result.Should().Be(4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] leftEndPts = {1, 1, 3, 6, 7, 9, 9};
            int[] rightEndPts = {5, 5, 6, 6, 8, 9, 10};

            var result = _analyser.MaxNonOverlappingSetSize(leftEndPts, rightEndPts);
            result.Should().Be(4);
        }

        [TestMethod]
        public void AllOverlapping()
        {
            int[] leftEndPts = { 1, 2, 3, 4, 5 };
            int[] rightEndPts = { 5, 6, 7, 8, 9 };

            var result = _analyser.MaxNonOverlappingSetSize(leftEndPts, rightEndPts);
            result.Should().Be(0);
        }

        [TestMethod]
        public void SinglePoint()
        {
            int[] leftEndPts = { 1 };
            int[] rightEndPts = { 5 };

            var result = _analyser.MaxNonOverlappingSetSize(leftEndPts, rightEndPts);
            result.Should().Be(1);
        }

        [TestMethod]
        public void AllPoints()
        {
            int[] leftEndPts = { 1, 1, 1, 5 };
            int[] rightEndPts = { 1, 1, 1, 5 };

            var result = _analyser.MaxNonOverlappingSetSize(leftEndPts, rightEndPts);
            result.Should().Be(2);
        }

        [TestMethod]
        public void EmptyArray()
        {
            int[] leftEndPts = {};
            int[] rightEndPts = {};

            var result = _analyser.MaxNonOverlappingSetSize(leftEndPts, rightEndPts);
            result.Should().Be(0);
        }

        [TestMethod]
        public void EdgeCases()
        {
            int[] leftEndPts = {0, 3, 6, 7, 9, 9};
            int[] rightEndPts = {5, 6, 6, 8, 9, 1000000000};

            var result = _analyser.MaxNonOverlappingSetSize(leftEndPts, rightEndPts);
            result.Should().Be(4);
        }


        [TestMethod]
        public void SegmentClassTest()
        {
            var a = new Segment(1, 5);
            var b = new Segment(3, 6);
            var c = new Segment(7, 8);
            var d = new Segment(9, 9);
            var e = new Segment(9, 10);

            a.OverlapsWith(b).Should().BeTrue();
            b.OverlapsWith(a).Should().BeTrue();
            a.OverlapsWith(c).Should().BeFalse();
            d.OverlapsWith(e).Should().BeTrue();
        }
    }
}