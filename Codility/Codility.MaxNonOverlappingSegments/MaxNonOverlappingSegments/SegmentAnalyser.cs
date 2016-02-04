using System;
using System.Collections.Generic;

namespace MaxNonOverlappingSegments
{
    public class SegmentAnalyser
    {
        private readonly List<Segment> _segments = new List<Segment>();

        public int MaxNonOverlappingSetSize(int[] leftEndPts, int[] rightEndPts)
        {
            InitialiseSegmentList(leftEndPts, rightEndPts);

            return ZeroOrOneSegments() ? _segments.Count : CalculateNumNonOverlapping();
        }


        private bool ZeroOrOneSegments() => _segments.Count <= 1;

        private int CalculateNumNonOverlapping()
        {
            var numNonOverlapping = 0;

            var currentSegment = 0;
            var nextSegment = 1;
            while (nextSegment < _segments.Count)
            {
                if (_segments[nextSegment].OverlapsWith(_segments[currentSegment]))
                {
                    nextSegment++;
                }
                else
                {
                    numNonOverlapping++;
                    currentSegment = nextSegment;
                    nextSegment = currentSegment + 1;
                }
            }


            if (numNonOverlapping == 0)
                return 0;
            else
                return numNonOverlapping + 1;
        }

        private void InitialiseSegmentList(int[] leftEndPts, int[] rightEndPts)
        {
            if (leftEndPts.Length != rightEndPts.Length) throw new ArgumentOutOfRangeException();

            for (var i = 0; i < leftEndPts.Length; i++)
                _segments.Add(new Segment(leftEndPts[i], rightEndPts[i]));
        }
    }

    public class Segment
    {
        public Segment(int left, int right)
        {
            Left = left;
            Right = right;
        }

        public int Left { get; set; }
        public int Right { get; set; }

        public bool OverlapsWith(Segment other)
            => (other.Left >= Left && other.Left <= Right) || (other.Right >= Left && other.Right <= Right);
    }
}