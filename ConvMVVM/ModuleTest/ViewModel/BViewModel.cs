using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Service.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModuleTest.ViewModel
{
    partial class BViewModel : NotifyObject , IModalDialogViewModel, IInject<int>
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

        public void Inject(int instance)
        {

            System.Diagnostics.Debug.WriteLine("test");
        }


        #region Command
        [RelayCommand]
        public void Test()
        {
            this.dialogService.ShowDialog(this, "CWindowView", "there is no cow level", 500, 500);
        }
        #endregion
    }
}
