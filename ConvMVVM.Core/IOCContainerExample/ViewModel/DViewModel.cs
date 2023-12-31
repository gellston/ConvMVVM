using IOCContainerExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerExample.ViewModel
{
    public class DViewModel
    {
        #region Constructor
        public DViewModel() { }
        #endregion

        #region Public Property
        public AModel AModel { get; set; }
        public BModel BModel { get; set; }
        public CModel CModel { get; set;}
        #endregion
    }
}
