using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using ConvMVVM.Core.Service.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModuleTest.ViewModel
{
    partial class BViewModel : NotifyObject , IModalDialogViewModel
    {

        #region Private Property
        private IDialogService dialogService;
        #endregion

        #region Constructor
        public BViewModel(IDialogService _dialogService)
        {
            this.dialogService = _dialogService;
        }
        #endregion

        public bool DialogResult { get; set; } = true;

        public string Title { get; set; } = "";


        #region Command
        [RelayCommand]
        public void Test()
        {
            this.dialogService.ShowDialog(this, "AWindowView", "there is no cow level", 500, 500);
        }
        #endregion
    }
}
