using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityDemoLib
{
    public class Demo
    {
        public static int Solution(int[] a)
        {
            var equilibiumIndex = -1;

            for (var p = 0; p < a.Length; p++)
            {
                try
                {
                    var lowerSum = Demo.LowerSum(a, p);
                    var upperSum = Demo.UpperSum(a, p);

                    if (lowerSum != upperSum) continue;
                    equilibiumIndex = p;
                    break;
                }
                catch (OverflowException)
                {
                }
            }

            return equilibiumIndex;
        }

        public static int LowerSum(int[] a, int p)
        {
            var sum = 0;

            for (var index = 0; index < p; index++)
            {
                sum = checked(sum + a[index]);
            }

            return sum;
        }

        public static int UpperSum(int[] a, int p)
        {
            var sum = 0;

            for (var index = p + 1; index < a.Length; index++)
                sum = checked(sum + a[index]);

            return sum;
        }
    }
}
