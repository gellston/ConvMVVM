using ConvMVVM.Core.Component;
using ConvMVVM.Core.Service.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTest.ViewModel
{
    internal class AWindowViewModel : NotifyObject, IModalDialogViewModel
    {

        #region Constructor
        public AWindowViewModel()
        {

        }

        public bool DialogResult { get; set; } = true;

        public string Title { get; set; } = "";
        #endregion
    }
}
