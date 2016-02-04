using System.Collections.Generic;
using System.Linq;

namespace PermMissingElement
{
    public class ContiguousIntArray
    {
        private readonly Dictionary<int,bool> _expectedValues = new Dictionary<int, bool>();

        public int MissingValue(int[] a)
        {
            InitialiseExpectedValues(a);
            MarkWhereExpectedValuesFound(a);

            return ValueMissingFromExpectedValues();
        }



        private void InitialiseExpectedValues(int[] a)
        {
            foreach (var i in Enumerable.Range(1, a.Length + 1).ToList())
                _expectedValues.Add(i, false);
        }

        private void MarkWhereExpectedValuesFound(int[] a)
        {
            foreach (var i in a)
                _expectedValues[i] = true;
        }

        private int ValueMissingFromExpectedValues()
        {
            return _expectedValues.FirstOrDefault(element => element.Value == false).Key;
        }
    }
}
