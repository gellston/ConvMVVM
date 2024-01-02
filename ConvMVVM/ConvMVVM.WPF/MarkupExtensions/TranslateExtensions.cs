using ConvMVVM.WPF.Service.ResourceContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ConvMVVM.WPF.MarkupExtensions
{
    public class TranslateExtensions : Binding
    {
        #region Private Property

        #endregion

        #region Constructor

        public TranslateExtensions(string path) : base("[" + path + "]")
        {
            this.Mode = BindingMode.OneWay;
            this.Source = ResourceContainer.Instance;

        }
        #endregion

    };

}
