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

        #region Constructor
        public AViewModel() { 
        
            
        }
        #endregion

        #region Property

        [Property]
        private string _Name = "";

        [Property]
        private string _Test = "";

        public void test()
        {
            this.Name = "";

           
        }
        #endregion
    }
}
