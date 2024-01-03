using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using IOCContainerExample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerExample.ViewModel
{
    public partial class MainWindowViewModel : NotifyObject
    {

        #region Private Property
        private readonly ITestService testService;
        #endregion

        #region Constructor
        public MainWindowViewModel(ITestService testService) {
            this.testService = testService;

            System.Diagnostics.Debug.WriteLine(this.testService.Test());
        }
        #endregion


    }
}
