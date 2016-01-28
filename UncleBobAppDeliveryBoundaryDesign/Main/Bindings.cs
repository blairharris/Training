using Application;
using Delivery;
using Ninject.Modules;

namespace Delivery
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IRequestBoundary>().To<Interactor>();
            Bind<IResponseBoundary>().To<Presenter>();
        }
    }
}
