using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNonDivisors
{
    public class NonDivisorsAlgorithm
    {
        public int[] Calculate(int[] a)
        {
            var nonDivisors = new int[a.Length];

            for (var i = 0; i < a.Length; i++)
            {
                nonDivisors[i] = a.Length - 1;
                for (var j = 0; j < a.Length; j++)
                {
                    if (j == i) continue;
                    if (a[j] > a[i]) continue;
                    if (a[i]%a[j] == 0) nonDivisors[i]--;
                }
            }

            return nonDivisors;
        }
    }
}
