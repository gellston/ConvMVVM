using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RelayCommandExample.ViewModel
{
    partial class MainWindowViewModel : NotifyObject
    {
        #region Constructor
        public MainWindowViewModel() { 

        }
        #endregion

        #region Command
        [RelayCommand]
        private void Test()
        {
            System.Diagnostics.Debug.WriteLine("no delay!!");
        }
        [AsyncRelayCommand]
        private async Task AsyncTest()
        {
            await Task.Delay(10000);
            System.Diagnostics.Debug.WriteLine("delay!!");
        }
        #endregion
    }
}
