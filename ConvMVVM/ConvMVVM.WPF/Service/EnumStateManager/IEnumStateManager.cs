using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.WPF.Service.EnumStateManager
{
    public interface IEnumStateManager
    {

        #region Public Functions
        public void ChangeState(string key, string value);
        public void ChangeState<T>(T state) where T : Enum;

        public string CheckState(string key);
        public string CheckState<T>(T state)where T : Enum;
        #endregion
    }
}
