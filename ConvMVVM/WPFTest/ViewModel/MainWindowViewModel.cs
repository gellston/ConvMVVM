using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using ConvMVVM.Core.Service.DialogService;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTest.ViewModel
{
    partial class MainWindowViewModel : NotifyObject
    {
        #region Private Property
        private readonly IDialogService dialogService;
        #endregion

        #region Constructor
        public MainWindowViewModel(IDialogService _dialogService) { 
        
           this.dialogService = _dialogService;
        }
        #endregion

        #region Command

        [RelayCommand]
        private void Test()
        {

            this.dialogService.ShowDialog(this, "BView", "there is no cow level", 500, 500);

        }

        #endregion
    }
}
