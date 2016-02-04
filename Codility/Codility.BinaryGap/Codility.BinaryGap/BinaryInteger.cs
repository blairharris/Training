using System;
namespace Codility.BinaryGap
{
    public class BinaryInteger
    {
        private readonly string _binaryString;
        private int _index;

        public BinaryInteger(int n)
        {
            _binaryString = Convert.ToString(n, 2);
        }

        public int MaxBinaryGap()
        {
            var maxGap = 0;

            _index = 0;
            while (_index < _binaryString.Length)
            {
                MoveToNextOneFollowedByZero();
                var gap = WalkGapAndCalculateSize();
                if (gap > maxGap) maxGap = gap;
            }

            return maxGap;
        }


        private void MoveToNextOneFollowedByZero()
        {
            var indexOfNextOneFollowedByZero = _binaryString.IndexOf('0', _index);
            _index = indexOfNextOneFollowedByZero == -1 ? _binaryString.Length : indexOfNextOneFollowedByZero - 1;
        }

        private int WalkGapAndCalculateSize()
        {
            int gap = 0;

            _index++;
            while (_index < _binaryString.Length)
            {
                if (_binaryString[_index] == '1') break;
                gap++;
                _index++;
            }

            if (_index == _binaryString.Length)
                gap = 0;

            return gap;
        }
    }
}
