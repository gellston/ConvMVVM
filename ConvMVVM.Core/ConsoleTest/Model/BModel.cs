using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Model
{
    public class BModel
    {
        #region Private Property
        private readonly AModel model;
        #endregion

        #region Constructor
        public BModel(AModel _model) { 
        
            this.model = _model;
        }
        #endregion
    }
}
