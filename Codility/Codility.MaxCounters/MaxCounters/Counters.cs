using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxCounters
{
    public class Counters
    {
        private List<Counter> _counters;
        private int _initialCounterValue = 0;

        public int[] Operate(int numCounters, int[] operations)
        {
            _counters = new List<Counter>();

            foreach (var operation in operations)
            {
                if (operation >= 1 && operation <= numCounters)
                {
                    IncrementCounter(operation);
                }
                else if (operation == numCounters + 1)
                {
                    if(_counters.Count == 0)
                        _counters.Add(new Counter(1,0));
                    else
                        SetAllCountersToMaxValue();
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            return ConvertToOutputArray(numCounters);
        }

        private int[] ConvertToOutputArray(int numCounters)
        {
            int[] output = new int[numCounters];

            for (var i = 0; i < numCounters; i++)
            {
                output[i] = _initialCounterValue;
            }

            foreach (var counter in _counters)
            {
                output[counter.Position-1] = counter.Value;
            }

            return output;
        }

        private void IncrementCounter(int operation)
        {
            var found = false;

            foreach (var c in _counters.Where(c => c.Position == operation))
            {
                found = true;
                c.Value++;
            }

            if(!found)
                _counters.Add(new Counter(operation, _initialCounterValue + 1));
        }

        private void SetAllCountersToMaxValue()
        {
            _initialCounterValue = _counters.Max(c => c.Value);

            foreach (var counter in _counters)
                counter.Value = _initialCounterValue;
        }
    }

    internal class Counter
    {
        public Counter(int position, int value)
        {
            Position = position;
            Value = value;
        }

        public int Position { get; set; }
        public int Value { get; set; }
    }
}
