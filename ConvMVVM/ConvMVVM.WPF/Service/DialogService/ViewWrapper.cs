using ConvMVVM.Core.Service.DialogService;
using ConvMVVM.WPF.Service.DialogService.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConvMVVM.WPF.Service.DialogService
{
    internal class ViewWrapper : IView
    {

        #region Private Property
        internal readonly WeakReference viewReference;
        #endregion


        #region Constructor
        internal ViewWrapper(FrameworkElement view)
        {
            if(view == null) throw new ArgumentNullException(nameof(view));

            viewReference = new WeakReference(view);

           
        }
        #endregion

        #region Property
        public bool IsAlive => viewReference.IsAlive;

        public object Source
        {
            get
            {
                if (!IsAlive) throw new InvalidOperationException("View has been garbage collected");
                if (viewReference.Target == null) throw new InvalidOperationException("View has been set to null");

                return viewReference.Target;
            }
        }

        public object DataContext
        {
            get
            {
                if (!IsAlive) throw new InvalidOperationException("View has been garbage collected");
                if (viewReference.Target == null) throw new InvalidOperationException("View has been set to null");

                var frameworkElement = viewReference.Target as FrameworkElement;
                if (frameworkElement == null) throw new InvalidOperationException("Invalid FrameworkElement");

                return frameworkElement.DataContext;
            }
        }

        #endregion


        #region Functions

        public object GetOwner()
        {
            
            FrameworkElement frameworkElement = this.Source as FrameworkElement;
            if (frameworkElement == null) return null;
            
            var window = Window.GetWindow(frameworkElement);
            return window;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is ViewWrapper other))
                return false;

            return Source.Equals(other.Source);
        }

        #endregion
    }
}
