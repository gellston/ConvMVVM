using ConvMVVM.Core.IOC;
using IOCContainerExample.Model;
using IOCContainerExample.Service;
using IOCContainerExample.ViewModel;

namespace IOCContainerExample
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Case1();
            Case2();
            Case3();
            Case4();
        }

        static void Case1()
        {
            var collection = ServiceCollection.Create();
            collection.RegisterCache<TestService>();
            collection.RegisterCache<ITestModel, TestModel>();
            
            var container = collection.CreateContainer();
            var tesetModel = container.GetService<ITestModel>();

        }

        static void Case2()
        {
            var collection = ServiceCollection.Create();
            collection.RegisterCache<AViewModel>();
            collection.RegisterNoneCache<Func<AModel, AViewModel>>((container)=>
            {
                return (model) =>
                {
                    var vm = container.GetService<AViewModel>();
                    vm.AModel = model;
                    return vm;
                };
            });

            var container = collection.CreateContainer();
            var converter = container.GetService<Func<AModel, AViewModel>>();
            var model = new AModel();
            var viewModel = converter(model);

        }

        static void Case3()
        {
            var collection = ServiceCollection.Create();
            collection.RegisterCache<AViewModel>();
            collection.RegisterNoneCache<Func<AModel, AViewModel>>((container) =>
            {
                return (model) =>
                {
                    var vm = container.GetService<AViewModel>();
                    vm.AModel = model;
                    return vm;
                };
            });
            collection.RegisterNoneCache<Func<List<AModel>, List<AViewModel>>>((container) =>
            {
                return (models) =>
                {
                    var converter = container.GetService<Func<AModel, AViewModel>>();
                    var vms = models.Select(model => converter(model)).ToList();
                    return vms;
                };
            });

            var container = collection.CreateContainer();
            var converter = container.GetService<Func<List<AModel>, List<AViewModel>>>();

            var models = new List<AModel>()
            {
                new AModel(),
                new AModel(),
                new AModel()
            };
            var viewModels = converter(models);


        }


        static void Case4()
        {
            var collection = ServiceCollection.Create();
            collection.RegisterCache<DViewModel>();
            collection.RegisterNoneCache<Func<AModel, BModel, CModel, DViewModel>>((container) =>
            {
                return (amodel, bmodel, cmodel) =>
                {
                    var vm = container.GetService<DViewModel>();
                    vm.AModel = amodel;
                    vm.BModel = bmodel;
                    vm.CModel = cmodel;
                    return vm;
                };
            });

            var container = collection.CreateContainer();


            var amodel = new AModel();
            var bmodel = new BModel();
            var cmodel = new CModel();

            var converter = container.GetService<Func<AModel, BModel, CModel, DViewModel>>();
            var viewModel = converter(amodel, bmodel, cmodel);

        }
    }
}
