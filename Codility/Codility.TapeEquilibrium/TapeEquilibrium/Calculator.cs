using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapeEquilibrium
{
    public class Calculator
    {
        public int MinDifference(int[] a)
        {
            var differences = new List<int>();

            var lowerSum = LowerSum(a, 1);
            var upperSum = UpperSum(a, 1);
            differences.Add(Math.Abs(lowerSum-upperSum));

            for (var index = 1; index < a.Length - 1; index++)
            {
                lowerSum = lowerSum + a[index];
                upperSum = upperSum - a[index];
                differences.Add(Math.Abs(lowerSum - upperSum));
            }

            return differences.Count == 0 ? -1 : differences.Min();
        }


        private int LowerSum(int[] a, int p)
        {
            var sum = 0;

            for (var index = 0; index < p; index++)
                sum = checked(sum + a[index]);

            return sum;
        }

        private int UpperSum(int[] a, int p)
        {
            var sum = 0;

            for (var index = p; index < a.Length; index++)
                sum = checked(sum + a[index]);

            return sum;
        }
    }
}
