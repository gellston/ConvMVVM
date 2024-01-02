using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConsoleTest
{
    partial class AViewModel
    {
        public AViewModel() { 
        
            
        }

        [Property]
        private string _Test2 = "";


        [RelayCommand]
        private void Test()
        {

        }
    }
}
