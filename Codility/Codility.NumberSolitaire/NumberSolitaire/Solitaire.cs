using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NumberSolitaire
{
    public class Solitaire
    {
        public int MaxScore(int[] board)
        {
            if( board.Length < 2)
                throw new ArgumentOutOfRangeException();
            else if (board.Length == 2)
                return board.Sum();
            else
            {
                var pos = 0;
                var score = board[pos];

                while (pos < board.Length - 1)
                {
                    if (NoPositiveSquaresInNextSix(pos,board) && WithinReachOfEnd(pos,board))
                        score += MoveToEnd(ref pos, board);
                    else if (NoPositiveSquaresInNextSix(pos, board) && !WithinReachOfEnd(pos, board))
                        score += MoveToHighestSquareInNextSix(ref pos, board);
                    else
                        score += MoveToEachPositiveSquareInTurn(ref pos, board);
                }

                return score;
            }
        }

        private int MoveToEachPositiveSquareInTurn(ref int pos, int[] board)
        {
            var score = 0;
            var indexOfLastPositiveSquare = -1;
            for (var i = pos + 1; i < pos + 6 && i < board.Length - 1; i++)
            {
                if (board[i] > 0)
                {
                    score += board[i];
                    indexOfLastPositiveSquare = i;
                }
            }
            pos = indexOfLastPositiveSquare;

            return score;
        }

        private int MoveToHighestSquareInNextSix(ref int pos, int[] board)
        {
            var max = int.MinValue;
            var indexOfMax = -1;
            for (var i = pos + 1; i < pos + 6 && i < board.Length - 1; i++)
            {
                if (board[i] > max)
                {
                    max = board[i];
                    indexOfMax = i;
                }
            }
            pos = indexOfMax;

            return max;
        }

        private int MoveToEnd(ref int pos, int[] board)
        {
            pos = board.Length - 1;
            return board[pos];
        }

        private bool WithinReachOfEnd(int pos, int[] board)
        {
            return pos + 6 >= board.Length - 1;
        }

        private bool NoPositiveSquaresInNextSix(int pos, int[] board)
        {
            for(var i = pos + 1; i < pos + 6 && i < board.Length - 1; i++)
                if (board[i] > 0) return false;

            return true;
        }
    }
}
