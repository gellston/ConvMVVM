using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerExample.Service
{
    public class TestService
    {

        #region Consturctor
        public TestService() { }
        #endregion

        #region Public Property
        public string Test()
        {
            return "there is no cow level";
        }
        #endregion
    }
}
