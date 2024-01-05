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
    partial class BViewModel : NotifyObject
    {
        #region Constructor
        public BViewModel() { 
        
        
        }
        #endregion


        #region Public Property

        [Property]
        private string _Test = "";
        #endregion


        #region Event Handler
        public override void OnActive()
        {
            WeakReferenceMessenger.Default.Register<BViewModel, string>(this, (receiver, message) =>
            {
                this.Test = message;
            });
        }
        #endregion
    }
}
