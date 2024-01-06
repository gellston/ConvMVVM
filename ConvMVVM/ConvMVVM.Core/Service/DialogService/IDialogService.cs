
using ConvMVVM.Core.IOC;

namespace ConvMVVM.Core.Service.DialogService
{
    public interface IDialogService
    {

        #region Function
        public void SetServiceProvider(IServiceContainer serviceProvider);

        public void RegisterDialog(Type type);
        public void RegisterDialog<TWindow>() where TWindow : class;


        public bool Close(System.ComponentModel.INotifyPropertyChanged viewModel);
        public bool Activate(System.ComponentModel.INotifyPropertyChanged viewModel);

        public bool ShowDialog(System.ComponentModel.INotifyPropertyChanged ownerViewModel, string windowName, string title, int width, int height);
        public bool ShowDialog(System.ComponentModel.INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel, string title, int width, int height);
        public void Show(System.ComponentModel.INotifyPropertyChanged ownerViewModel, string windowName, int width, int height);
        public void Show(System.ComponentModel.INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel, int width, int height);
        #endregion

    }
}
