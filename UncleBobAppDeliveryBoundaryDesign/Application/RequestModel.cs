using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class RequestModel
    {
        public RequestModel(int a, int b)
        {
            A = a;
            B = b;
        }

        public int A { get; set; }
        public int B { get; set; }
    }
}
