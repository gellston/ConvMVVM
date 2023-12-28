using ConsoleTest.Model;
using ConvMVVM.Core.DI;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var collection = ServiceCollection.Create();
            collection.RegisterNoneCache<AModel>();
            collection.RegisterCache<BModel>();

            collection.RegisterCache<CModel>((serviceProvider) =>
            {
                var model = new CModel();

                return model;
            });

            var container = collection.CreateContainer();


            var aModel = container.GetService<AModel>();
            var bModel = container.GetService<BModel>();






            System.Diagnostics.Debug.WriteLine(aModel.ToString());
        }
    }
}
