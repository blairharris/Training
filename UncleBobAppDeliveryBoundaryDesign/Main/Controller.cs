using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;

namespace Delivery
{
    public class Controller
    {
        private IRequestBoundary _requestBoundary;
        private Presenter _presenter;

        public Controller(IRequestBoundary requestBoundary, Presenter presenter)
        {
            _requestBoundary = requestBoundary;
            _presenter = presenter;
        }

        public void Execute()
        {
            _requestBoundary.AddPositiveIntegers(new RequestModel(1, 2));
        }
    }
}
