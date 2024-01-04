using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoViewTemplateSelector.ViewModel
{
    partial class MainWindowViewModel : NotifyObject
    {

        #region Constructor
        public MainWindowViewModel() { 
        
        }
        #endregion

        #region Public Property
        [Property]
        private ObservableCollection<INotifyPropertyChanged> _ViewModelCollection = new ObservableCollection<INotifyPropertyChanged>();

        [Property]
        private AViewModel _AViewModel = null;

        [Property]
        private DViewModel _DViewModel = null;
        #endregion

        #region Command
        [RelayCommand]
        private void Update()
        {
            try
            {
                this.AViewModel = new AViewModel();
                this.DViewModel = new DViewModel();
                this.ViewModelCollection.Add(new AViewModel());
                this.ViewModelCollection.Add(new BViewModel());
                this.ViewModelCollection.Add(new CViewModel());

            }
            catch(Exception ex)
            {

            }
        }

        #endregion
    }
}
