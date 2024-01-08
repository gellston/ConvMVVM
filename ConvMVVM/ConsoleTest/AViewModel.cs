using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using ConvMVVM.Core.Messenger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConsoleTest
{
    partial class AViewModel : NotifyObject
    {
        public AViewModel() { 
        
           this.Test2 = new ObservableCollection<string>();
          
        }

        private string _Test22 = "false";

        [Property]
        private ObservableCollection<string> _Test2 = null;


        [AsyncRelayCommand]
        public async Task Test()
        {
            await WeakReferenceMessenger.Default.AsyncSend("tes1231231231231t");
        }

        #region Functions
        public override void OnActive()
        {
            System.Diagnostics.Debug.WriteLine("test");
        }
        #endregion

    }
}
