using ConvMVVM.Core.IOC;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel;

using System.Windows;

namespace ConvMVVM.WPF.Service.ViewModelLocator
{
    public class ViewModelLocator
    {

        #region Private Property
        private static IServiceContainer serviceProvider { get; set; } = null;
        #endregion

        #region Attached Property
        public static DependencyProperty AutoWireViewModelProperty = DependencyProperty.RegisterAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(defaultValue: false, propertyChangedCallback: OnAutoWireViewModelChanged));
        #endregion

        #region Static Function
        public static void SetServiceProvider(IServiceContainer _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }
        #endregion

        #region Callback
        public static bool GetAutoWireViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoWireViewModelProperty, value);
        }
        #endregion

        #region Static Function
        private static bool IsInDesignMode(DependencyObject element)
        {
            return DesignerProperties.GetIsInDesignMode(element);
        }

        private static void OnAutoWireViewModelChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
        {
            if (!IsInDesignMode(element))
            {
                var frameworkElement = element as FrameworkElement;
                if (frameworkElement != null)
                {
                    if ((bool)args.NewValue == true)
                    {

                        frameworkElement.Initialized += FrameworkElement_Initialized;
                    }
                    else
                    {
                        frameworkElement.Initialized -= FrameworkElement_Initialized;
                    }
                }
            }
        }
        #endregion

        #region Event Handler
        private static void FrameworkElement_Initialized(object sender, EventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            var typeName = frameworkElement.GetType().Name;
            var viewModelName = typeName.Replace("View", "ViewModel");

            var type = serviceProvider.KeyType(viewModelName);
            var viewModel = serviceProvider.GetService(type);
            frameworkElement.DataContext = viewModel;
        }
        #endregion



    }

}
