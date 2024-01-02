using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventToCommandExample.ViewModel
{
    partial class MainWindowViewModel : NotifyObject
    {

        #region Command
        [RelayCommand]
        private void Loaded1()
        {
            System.Diagnostics.Debug.WriteLine("View Loaded!!");
        }

        [RelayCommand]
        private void Loaded2(object param)
        {
            System.Diagnostics.Debug.WriteLine("View Loaded!!");
        }
        #endregion
    }
}
