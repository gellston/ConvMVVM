using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using UnitTestSharp.Interface;
using UnitTestSharp.Model;

namespace UnitTestSharp
{
    [TestClass]
    public class IocContainerTest
    {
        [TestMethod]
        public void CreateCollection()
        {

            var collection = ConvMVVM.Core.IOC.ServiceCollection.Create();

            Assert.IsNotNull(collection, "collection null check");
        }

        [TestMethod]
        public void ContainerCreation()
        {

            var collection = ConvMVVM.Core.IOC.ServiceCollection.Create();
            var container = collection.CreateContainer();

            Assert.IsNotNull(collection, "collection null check");
            Assert.IsNotNull(container, "container null check");
        }


        [TestMethod]
        public void CacheObjectTest1()
        {

            var collection = ConvMVVM.Core.IOC.ServiceCollection.Create();
            collection.RegisterCache<AModel>();
            collection.RegisterCache<IBModel, BModel>();

            var container1 = collection.CreateContainer();

            var aModel1 = container1.GetService<AModel>();
            var aModel2 = container1.GetService<AModel>();
            var bModel1 = container1.GetService<IBModel>();
            var bModel2 = container1.GetService<IBModel>();

            Assert.AreEqual(aModel1, aModel2, "A model must be equal");
            Assert.AreEqual(bModel1, bModel2, "B model must be equal");
        }

        [TestMethod]
        public void CacheObjectTest2()
        {

            var collection = ConvMVVM.Core.IOC.ServiceCollection.Create();
            collection.RegisterCache<AModel>((container) =>
            {
                var model = new AModel();

                return model;
            });
            collection.RegisterCache<IBModel, BModel>((container) =>
            {
                var model = new BModel();
                return model;
            });

            var container1 = collection.CreateContainer();

            var aModel1 = container1.GetService<AModel>();
            var aModel2 = container1.GetService<AModel>();
            var bModel1 = container1.GetService<IBModel>();
            var bModel2 = container1.GetService<IBModel>();

            Assert.AreEqual(aModel1, aModel2, "A model must be equal");
            Assert.AreEqual(bModel1, bModel2, "B model must be equal");
        }


        [TestMethod]
        public void CacheObjectTest3()
        {

            var collection = ConvMVVM.Core.IOC.ServiceCollection.Create();
            collection.RegisterCache<AModel>();
            collection.RegisterCache<IBModel, BModel>();
            collection.RegisterCache<CModel>();

            var container1 = collection.CreateContainer();

            var aModel1 = container1.GetService<AModel>();
            var aModel2 = container1.GetService<AModel>();
            var bModel1 = container1.GetService<IBModel>();
            var bModel2 = container1.GetService<IBModel>();

            var cModel1 = container1.GetService<CModel>();

            Assert.AreEqual(aModel1, aModel2, "A model must be equal");
            Assert.AreEqual(bModel1, bModel2, "B model must be equal");
            Assert.AreEqual(cModel1.AModel, aModel1, "C model property(AModel) must be equal");
            Assert.AreEqual(cModel1.BModel, bModel1, "C model property(BModel) must be equal");
        }


        [TestMethod]
        public void CacheObjectTest4()
        {

            var collection = ConvMVVM.Core.IOC.ServiceCollection.Create();
            collection.RegisterCache<AModel>();
            collection.RegisterCache<IBModel, BModel>();
            collection.RegisterCache<CModel>();

            var container1 = collection.CreateContainer();

            var aModel1 = container1.GetService<AModel>();
            var aModel2 = container1.GetService<AModel>();
            var bModel1 = container1.GetService<IBModel>();
            var bModel2 = container1.GetService<IBModel>();

            var cModel1 = container1.GetService<CModel>();

            Assert.AreEqual(aModel1, aModel2, "A model must be equal");
            Assert.AreEqual(bModel1, bModel2, "B model must be equal");
            Assert.AreEqual(cModel1.AModel, aModel1, "C model property(AModel) must be equal");
            Assert.AreEqual(cModel1.BModel, bModel1, "C model property(BModel) must be equal");
        }


        [TestMethod]
        public void CacheObjectTest5()
        {

            var collection = ConvMVVM.Core.IOC.ServiceCollection.Create();
            collection.RegisterCache<AModel>(new AModel());
            collection.RegisterCache<IBModel>(new BModel());
            collection.RegisterCache<CModel>();


            var container1 = collection.CreateContainer();

            var aModel1 = container1.GetService<AModel>();
            var aModel2 = container1.GetService<AModel>();
            var bModel1 = container1.GetService<IBModel>();
            var bModel2 = container1.GetService<IBModel>();

            var cModel1 = container1.GetService<CModel>();

            Assert.AreEqual(aModel1, aModel2, "A model must be equal");
            Assert.AreEqual(bModel1, bModel2, "B model must be equal");
            Assert.AreEqual(cModel1.AModel, aModel1, "C model property(AModel) must be equal");
            Assert.AreEqual(cModel1.BModel, bModel1, "C model property(BModel) must be equal");
        }


        [TestMethod]
        public void NoneCacheObjectTest1()
        {

            var collection = ConvMVVM.Core.IOC.ServiceCollection.Create();
            collection.RegisterNoneCache<AModel>();
            collection.RegisterNoneCache<IBModel, BModel>();
            collection.RegisterNoneCache<CModel>();

            var container1 = collection.CreateContainer();

            var aModel1 = container1.GetService<AModel>();
            var aModel2 = container1.GetService<AModel>();
            var bModel1 = container1.GetService<IBModel>();
            var bModel2 = container1.GetService<IBModel>();

            var cModel1 = container1.GetService<CModel>();

            Assert.AreNotEqual(aModel1, aModel2, "A model must be not equal");
            Assert.AreNotEqual(bModel1, bModel2, "B model must be not equal");
            Assert.AreNotEqual(cModel1.AModel, aModel1, "C model property(AModel) must be not equal");
            Assert.AreNotEqual(cModel1.BModel, bModel1, "C model property(BModel) must be not equal");
        }



        [TestMethod]
        public void NoneCacheObjectTest2()
        {

            var collection = ConvMVVM.Core.IOC.ServiceCollection.Create();
            collection.RegisterNoneCache<AModel>((container) =>
            {
                return new AModel();
            });
            collection.RegisterNoneCache<IBModel, BModel>((container) =>
            {
                return new BModel();
            });
            collection.RegisterNoneCache<CModel>((container) =>
            {
                var aModel = container.GetService<AModel>();
                var bModel = container.GetService<IBModel>();
                var cModel = new CModel(aModel, bModel);
                return cModel;
            });

            var container1 = collection.CreateContainer();

            var aModel1 = container1.GetService<AModel>();
            var aModel2 = container1.GetService<AModel>();
            var bModel1 = container1.GetService<IBModel>();
            var bModel2 = container1.GetService<IBModel>();

            var cModel1 = container1.GetService<CModel>();
            var cModel2 = container1.GetService<CModel>();

            Assert.AreNotEqual(aModel1, aModel2, "A model must be not equal");
            Assert.AreNotEqual(bModel1, bModel2, "B model must be not equal");
            Assert.AreNotEqual(cModel1.AModel, aModel1, "C model property(AModel) must be not equal");
            Assert.AreNotEqual(cModel1.BModel, bModel1, "C model property(BModel) must be not equal");
            Assert.AreNotEqual(cModel2.AModel, aModel1, "C model property(AModel) must be not equal");
            Assert.AreNotEqual(cModel2.BModel, bModel1, "C model property(BModel) must be not equal");
            Assert.AreNotEqual(cModel1, cModel2, "C Model1 and Model2 must be not equal");

        }
    }
}