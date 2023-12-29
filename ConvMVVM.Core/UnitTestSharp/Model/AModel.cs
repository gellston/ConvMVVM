using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestSharp.Interface;

namespace UnitTestSharp.Model
{
    public class AModel : IAModel
    {

        #region Constructor
        public AModel()
        {

        }
        #endregion

        #region Property
        public string Test { get; } = "Test1";
        #endregion
    }
}
