using System.Collections.Generic;
using System.Linq;

namespace OddOccurrencesInArray
{
    public class ArrayParser
    {
        private readonly Dictionary<int, int> _elements = new Dictionary<int, int>();

        public int ValueOfUnpairedElement(int[] a)
        {
            foreach (var val in a)
            {
                if (ValueIsInDictionary(val))
                    IncrementFrequency(val);
                else
                    AddValueToDictionary(val);
            }

            return FirstValueWithOddFrequency();
        }



        private bool ValueIsInDictionary(int val)
        {
            return _elements.ContainsKey(val);
        }

        private void IncrementFrequency(int val)
        {
            _elements[val]++;
        }

        private void AddValueToDictionary(int val)
        {
            _elements.Add(val, 1);
        }

        private int FirstValueWithOddFrequency()
        {
            return _elements.First(element => IsOdd(element.Value)).Key;
        }

        private bool IsOdd(int val) => val%2 == 1;
    }
}
