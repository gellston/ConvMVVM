using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTest.ViewModel
{
    public partial class AViewModel : NotifyObject
    {
        #region Constructor
        public AViewModel()
        {

        }
        #endregion


        #region Property
        [Property]
        public string _Name;
        #endregion

        #region Command
        public ICommand TestCommand
        {
            get => new RelayCommand(() =>
            {
                this.Name = "there is no cow level";
              
            });
        }
        #endregion
    }
}
