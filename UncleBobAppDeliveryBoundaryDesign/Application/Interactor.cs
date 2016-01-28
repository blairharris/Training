using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Interactor : IRequestBoundary
    {
        private IResponseBoundary _responseBoundary;

        public Interactor(IResponseBoundary responseBoundary)
        {
            _responseBoundary = responseBoundary;
        }

        public void AddPositiveIntegers(RequestModel input)
        {
            if (input.A < 0 || input.B < 0)
            {
                // call invalid input method in Presenter
                ResponseModel response = new ResponseModelError("Either A or B is negative");
                _responseBoundary.SetInvalidInput(response);
            }
            else
            {
                // call valid result SetSum in Presenter
                ResponseModel response = new ResponseModelOk(input.A + input.B);
                _responseBoundary.SetSum(response);
            }
        }
    }
}
