using ConvMVVM.Core.Component;
using ConvMVVM.Core.Service.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CModule.ViewModel
{
    public class CWindowViewModel: NotifyObject , IModalDialogViewModel
    {
        #region Constructor
        public CWindowViewModel() { 
        
        
        }

        public bool DialogResult { get; set; } = false;

        public string Title { get; set; } = "";
        #endregion
    }
}
