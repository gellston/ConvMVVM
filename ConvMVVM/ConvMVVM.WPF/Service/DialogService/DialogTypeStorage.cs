using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConvMVVM.WPF.Service.DialogService
{
    internal class DialogTypeStorage
    {

        #region Private Property
        internal static Dictionary<string, Type> noneCacheDialogType = new Dictionary<string, Type>();
        #endregion


        #region Static Function
        internal static void RegisterDialog(Type type)
        {

            if(!noneCacheDialogType.ContainsKey(type.Name))
            {
                noneCacheDialogType.Add(type.Name, type);
            }

        }


        internal static Type Dialog(string name)
        {
            if(!noneCacheDialogType.ContainsKey(name)) {
                return null;
            }

            return noneCacheDialogType[name];
        }

        internal static Window CreateDialog(string name)
        {
            var type = DialogTypeStorage.Dialog(name);
            if(type == null)
            {
                return null;
            }


            var view = (Window) Activator.CreateInstance(type);

            return view;
        }
        #endregion
    }
}
