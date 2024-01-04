



using ConvMVVM.Core.Messenger;

namespace ConsoleTest
{

    public class A
    {
        public A() {

            WeakReferenceMessenger.Default.Register<A, object>(this, (receiver, message) =>
            {

            });
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
  
        }
    }
}
