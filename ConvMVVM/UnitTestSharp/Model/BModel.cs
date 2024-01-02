using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestSharp.Interface;

namespace UnitTestSharp.Model
{
    public class BModel : IBModel
    {
        #region Constructor
        public BModel() { 
        
        }
        #endregion

        #region Property
        public string Test { get; } = "Test2";
        #endregion
    }
}
