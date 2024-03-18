using ConvMVVM.Core.Component;
using ConvMVVM.Core.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest.ViewModel
{
    public class AViewModel : NotifyObject, IInject<int>, IInject<double>
    {
        #region Constructor

        #endregion
        public void Inject(int instance)
        {


            System.Diagnostics.Debug.WriteLine("test");
        }

        public void Inject(double instance)
        {
            System.Diagnostics.Debug.WriteLine("test");
        }

        public void Inject(double instance, int test)
        {
            System.Diagnostics.Debug.WriteLine("test");
        }
    }
}
