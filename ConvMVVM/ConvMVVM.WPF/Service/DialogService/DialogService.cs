using ConvMVVM.Core.Component;
using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Service.DialogService;
using System.Windows;

namespace ConvMVVM.WPF.Service.DialogService
{
    internal class DialogService : IDialogService
    {
        #region Private Property
        private IServiceContainer container;
        #endregion

        #region Constructor
        internal DialogService()
        {

        }
        #endregion

        #region Protected Functions
        protected virtual Window FindOwnerWindow(System.ComponentModel.INotifyPropertyChanged viewModel)
        {
            IView? view = DialogServiceViews.Views.SingleOrDefault(registerView => {
                var window = registerView.GetOwner() as Window;
                if (window == null)
                {
                    return false;
                }
                return window.IsLoaded == true && ReferenceEquals(registerView.DataContext, viewModel);
             });


            if (view == null)
            {
                throw new NullReferenceException("Can't find viewModel's view");
            }

            Window? owner = view.GetOwner() as Window;
            if (owner == null)
            {
                throw new InvalidOperationException("View owner is not registered");
            }

            return owner;
        }
        #endregion

        #region Public Functions

        public void SetServiceProvider(IServiceContainer serviceProvider)
        {
            this.container = serviceProvider;
        }

        public void RegisterDialog(Type type)
        {
            DialogTypeStorage.RegisterDialog(type);
        }


        public void RegisterDialog<TWindow>() where TWindow : class
        {
            var type = typeof(TWindow);
            if(!type.IsSubclassOf(typeof(Window)))
                throw new ArgumentException(nameof(type));

            this.RegisterDialog(typeof(TWindow));
        }

        public bool Activate(System.ComponentModel.INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            Window? windowToActivate =
                (
                    from Window? window in Application.Current.Windows
                    where window != null
                    where viewModel.Equals(window.DataContext)
                    select window
                )
                .FirstOrDefault();

            return windowToActivate?.Activate() ?? false;

        }

        public bool Close(System.ComponentModel.INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            bool check = false;
            foreach (Window? window in Application.Current.Windows)
            {
                if (window == null || !viewModel.Equals(window.DataContext))
                {
                    continue;
                }

                try
                {
                    window.Close();
                    check = true;
                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    break;
                }
            }

            return check;
        }

        public bool ShowDialog(System.ComponentModel.INotifyPropertyChanged ownerViewModel, string windowName, string title, int width, int height)
        {

            Window window = DialogTypeStorage.CreateDialog(windowName);
            var name = windowName.Replace("View", "ViewModel");
            var viewModelType = this.container.KeyType(name);
            var viewModel = this.container.GetService(viewModelType) as IModalDialogViewModel;
            viewModel.Title = title;

            window.DataContext = viewModel;
            var ownerWindow = this.FindOwnerWindow(ownerViewModel);

            window.Owner = ownerWindow;
            window.Width = width;
            window.Height = height;
            window.ShowDialog();


            return viewModel.DialogResult;
        }

        public bool ShowDialog(System.ComponentModel.INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel, string title, int width, int height)
        {
            var viewModelName = viewModel.GetType().Name;
            var name = viewModelName.Replace("ViewModel", "View");
            Window window = DialogTypeStorage.CreateDialog(name);

            window.DataContext = viewModel;
            var ownerWindow = this.FindOwnerWindow(ownerViewModel);

            window.Owner = ownerWindow;
            window.Width = width;
            window.Height = height;
            window.ShowDialog();


            return viewModel.DialogResult;
        }

        public void Show(System.ComponentModel.INotifyPropertyChanged ownerViewModel, string windowName, int width, int height)
        {

            Window window = DialogTypeStorage.CreateDialog(windowName);
            var name = windowName.Replace("View", "ViewModel");
            var viewModelType = this.container.KeyType(name);
            var viewModel = this.container.GetService(viewModelType);

            window.DataContext = viewModel;
            var ownerWindow = this.FindOwnerWindow(ownerViewModel);

            window.Owner = ownerWindow;
            window.Width = width;
            window.Height = height;
            window.Show();

        }

        public void Show(System.ComponentModel.INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel, int width, int height)
        {
            var viewModelName = viewModel.GetType().Name;
            var name = viewModelName.Replace("ViewModel", "View");
            Window window = DialogTypeStorage.CreateDialog(name);

            window.DataContext = viewModel;
            var ownerWindow = this.FindOwnerWindow(ownerViewModel);

            window.Owner = ownerWindow;
            window.Width = width;
            window.Height = height;
            window.Show();

        }



        #endregion
    }
}
