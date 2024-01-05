using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using ConvMVVM.Core.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MessengerExample.ViewModel
{
    partial class AViewModel : NotifyObject
    {

        #region Constructor
        public AViewModel() { 
        
        
        }
        #endregion


        #region Command
        [RelayCommand]
        private void Test()
        {


            WeakReferenceMessenger.Default.Send("There is no cow level");
        }
        #endregion
    }
}
