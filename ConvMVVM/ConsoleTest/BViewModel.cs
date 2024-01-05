using ConvMVVM.Core.Component;
using ConvMVVM.Core.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class BViewModel : NotifyObject
    {

        #region Constructor
        public BViewModel() { 
        
        }
        #endregion

        #region Functions
        public override void OnActive()
        {
            WeakReferenceMessenger.Default.AsyncRegister<BViewModel, string>(this, async (receiver, message) =>
            {

                await Task.Delay(1000);
                System.Diagnostics.Debug.WriteLine("test!!!!!!!!!!!!!!!!!!!!!!!!!");
            });
        }
        #endregion
    }
}
