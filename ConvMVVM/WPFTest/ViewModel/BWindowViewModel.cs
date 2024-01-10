using ConvMVVM.Core.Component;
using ConvMVVM.Core.Service.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest.ViewModel
{
    public partial class BWindowViewModel : NotifyObject, IModalDialogViewModel
    {
        #region Constructor
        public BWindowViewModel()
        {

        }

        public bool DialogResult { get; set; } = true;

        public string Title { get; set; } = "";
        #endregion
    }
}
