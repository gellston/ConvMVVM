using IOCContainerExample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerExample.Model
{
    public class TestModel : ITestModel
    {
        #region Private Property
        private readonly TestService testService;
        #endregion

        #region Constructor
        public TestModel(TestService _testService) { 
            this.testService = _testService;
        }
        #endregion

        #region Functions
        public string Test()
        {
            return this.testService.Test();
        }
        #endregion
    }
}
