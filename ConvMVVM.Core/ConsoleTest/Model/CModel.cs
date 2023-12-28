using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Model
{
    public class CModel
    {
        #region Private Property
        private AModel _AModel = null;
        private BModel _BModel = null;
        #endregion

        #region Constructor
        public CModel()
        {

        }
        #endregion

        #region Property
        public AModel AModel
        {
            get
            {
                return _AModel;
            }

            set
            {
                _AModel = value;
            }
        }

        public BModel BModel
        {
            get
            {
                return _BModel;
            }

            set
            {
                _BModel = value;
            }
        }
        #endregion
    }
}
