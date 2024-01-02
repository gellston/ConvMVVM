using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainer.Service
{
    public class TestService : ITestService
    {

        #region Functions
        public string Test()
        {
            return "there is no cow level";
        }
        #endregion
    }
}
