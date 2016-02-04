using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility.CountSemiPrimes
{
    public class SemiPrimeCounter
    {
        public int[] CountSemiPrimes(int n, int[] p, int[] q)
        {
            int[] count = new int[p.Length];

            int[] primes = CalculatePrimes(n / 2);
            int[] semiPrimes = new int[n + 1];

            int sqrtN = (int)Math.Sqrt(n) + 1;
            bool keepLooping = true;
            var i = 0;
            while (keepLooping && i < n / 2)
            {
                var j = i;
                while (j < primes.Length)
                {
                    if (primes[i] > sqrtN && primes[j] > sqrtN)
                    {
                        keepLooping = false;
                        break;
                    }
                    var semiPrime = checked(primes[i] * primes[j]);
                    if (semiPrime > n) break;

                    semiPrimes[semiPrime] = 1;
                    j++;
                }
                i++;
            }

            Count_Fast(p, q, count, semiPrimes);

            return count;
        }

        private static void Count_Slow(int[] p, int[] q, int[] count, int[] semiPrimes)
        {
            for (var k = 0; k < p.Length; k++)
            {
                for (var m = p[k]; m <= q[k]; m++)
                    count[k] += semiPrimes[m];
            }
        }

        private static void Count_Fast(int[] p, int[] q, int[] count, int[] semiPrimes)
        {
            int[] prefixSums = new int[semiPrimes.Length];
            int[] postfixSums = new int[semiPrimes.Length+1];
            prefixSums[0] = semiPrimes[0];
            postfixSums[semiPrimes.Length - 1] = semiPrimes[semiPrimes.Length-1];
            for (var i = 1; i < semiPrimes.Length; i++)
            {
                prefixSums[i] = prefixSums[i - 1] + semiPrimes[i];
                postfixSums[semiPrimes.Length - 1 - i] = postfixSums[semiPrimes.Length - i] + semiPrimes[semiPrimes.Length - 1 - i];
            }

            var total = prefixSums[semiPrimes.Length-1];
            for(var j = 0; j < p.Length - 1; j++)
            {
                var start = p[j] - 1;
                var end = q[j] + 1;
                count[j] = total - prefixSums[start] - postfixSums[end];
            }
        }

        public int[] CalculatePrimes(int max)
        {
            int[] primes = Enumerable.Repeat(1, max+1).ToArray();
            primes[0] = 0;
            primes[1] = 0;
            var i = 2;
            while (i*i <= max)
            {
                if (primes[i] == 1)
                {
                    var k = i*i;
                    while (k <= max)
                    {
                        primes[k] = 0;
                        k += i;
                    }
                }
                i++;
            }

            var result = new List<int>();
            for (i = 0; i < max + 1; i++)
            {
                if(primes[i] == 1)
                    result.Add(i);
            }

            return result.ToArray();
        }
    }
}
