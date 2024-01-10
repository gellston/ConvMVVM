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
    public partial class AWindowViewModel : NotifyObject, IModalDialogViewModel
    {

        #region Private Property
        private readonly IDialogService dialogService;
        #endregion

        #region Constructor
        public AWindowViewModel(IDialogService _dialogService)
        {
            this.dialogService = _dialogService;

        }

        public bool DialogResult { get; set; } = true;

        public string Title { get; set; } = "";
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
