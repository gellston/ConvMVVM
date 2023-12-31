using IOCContainerExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerExample.ViewModel
{
    public class AViewModel
    {
        #region Constructor
        public AViewModel()
        {

        }
        #endregion

        #region Public Property
        public AModel AModel { get; set; }
        #endregion
    }
}
