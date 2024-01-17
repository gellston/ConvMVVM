using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConvMVVM.WPF.Service.EnumStateManager
{
    public class EnumStateManager : IEnumStateManager
    {

        #region Public Functions
        public void ChangeState(string key, string value)
        {
            try
            {
                EnumStateObject.Instance.ChangeState(key, value);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ChangeState<T>(T state) where T : Enum
        {
            try
            {
                EnumStateObject.Instance.ChangeState(state);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
