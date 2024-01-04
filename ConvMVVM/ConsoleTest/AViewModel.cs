using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
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
        
         
            
        }

        [Property]
        private ObservableCollection<string> _Test2 = null;


        [RelayCommand]
        private void Test()
        {

        }
    }
}
