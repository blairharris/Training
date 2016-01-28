using System.Reflection;
using Delivery;
using Application;
using Ninject;

namespace Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            IRequestBoundary requestBoundary = kernel.Get<IRequestBoundary>();
            Presenter presenter = new Presenter();

            Controller controller = new Controller(requestBoundary, presenter);
            controller.Execute();
        }
    }
}
