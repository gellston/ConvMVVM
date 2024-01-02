using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    partial class AViewModel : NotifyObject
    {
        public AViewModel() { 
        
            
        }

        [Property]
        private string _Test1 = "";

        private string _Test2 = "";
        public string Test2
        {
            get => _Test2;
            set => Property(ref _Test2, value);
        }
    }
}
