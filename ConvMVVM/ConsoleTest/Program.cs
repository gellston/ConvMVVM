
using ConvMVVM.Core.IOC;


namespace ConsoleTest
{

    public class A
    {
        public A() {


        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = ServiceCollection.Create();
            serviceCollection.RegisterNoneCache<AViewModel>();
            serviceCollection.RegisterNoneCache<BViewModel>();



            var container = serviceCollection.CreateContainer();

            var aViewModel = container.GetService<AViewModel>();
            var bViewModel = container.GetService<BViewModel>();

        }
    }
}
