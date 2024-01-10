using ConvMVVM.Core.Attributes;
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
    partial class AViewModel : NotifyObject
    {
        #region Private Property
        private readonly IDialogService dialogService;
        #endregion

        #region Constructor
        public AViewModel(IDialogService _dialogService) { 
        
            this.dialogService = _dialogService;
        }
        #endregion

        #region Command
        [RelayCommand]
        private void Test()
        {
            this.dialogService.ShowDialog(this, "BWindowView", "test", 500, 500);
        }
        #endregion
    }
}
