using System;
using Application;

namespace Delivery
{
    public class Presenter : IResponseBoundary
    {
        public void SetInvalidInput(ResponseModel response)
        {
            Console.WriteLine("ERROR: " + response.Output);
        }

        public void SetSum(ResponseModel response)
        {
            Console.WriteLine(response.Output);
        }
    }
}
