using ConvMVVM.Core.Component;
using ConvMVVM.Core.Service.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTest.ViewModel
{
    public class AWindowViewModel : NotifyObject, IModalDialogViewModel
    {
        #region Private Property
        private readonly IDialogService dialogService;
        #endregion


        #region Constructor
        public AWindowViewModel(IDialogService dialogService) { 

            this.dialogService = dialogService; 

        }

        public bool DialogResult { get; set; } = false;
        public string Title { get; set; } = "there is no cow level";
        #endregion


        #region Command
        public ICommand ConfirmCommand
        {
            get => new RelayCommand(() =>
            {

                this.DialogResult = true;
                this.dialogService.Close(this);
            });
        }

        public ICommand CancelCommand
        {
            get => new RelayCommand(() =>
            {
                this.DialogResult = false;
                this.dialogService.Close(this);

            });
        }

        #endregion


    }
}
