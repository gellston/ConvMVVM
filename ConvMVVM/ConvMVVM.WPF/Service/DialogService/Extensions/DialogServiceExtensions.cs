using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConvMVVM.WPF.Service.DialogService.Extensions
{
    internal static class DialogServiceExtensions
    {

        internal static Window GetOwner(this FrameworkElement frameworkElement)
        {
            var _window = frameworkElement as Window;
            if (_window != null)
                return _window;

            return  Window.GetWindow(frameworkElement);
        }
    }


}
