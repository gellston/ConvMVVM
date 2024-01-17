using ConvMVVM.WPF.Service.EnumStateManager;
using ConvMVVM.WPF.Service.ResourceContainer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ConvMVVM.WPF.MarkupExtensions
{
    public class EnumStateExtensions : Binding
    {
        #region Private Property

        #endregion

        #region Constructor
        public EnumStateExtensions(string path) : base("[" + path + "]")
        {
            this.Mode = BindingMode.OneWay;
            this.Source = EnumStateObject.Instance;
        }
        #endregion




    };
}
