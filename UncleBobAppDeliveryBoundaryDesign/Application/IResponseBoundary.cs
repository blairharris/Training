using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IResponseBoundary
    {
        void SetSum(ResponseModel response);
        void SetInvalidInput(ResponseModel response);
    }
}
