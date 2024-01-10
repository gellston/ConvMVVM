using ConvMVVM.Core.Service.DialogService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;

namespace ConvMVVM.WPF.Service.DialogService
{
    public class DialogServiceViews
    {

        #region Private Property
        private static readonly List<IView> InternalViews = new List<IView>();
        #endregion

        #region Attached Property
        public static DependencyProperty IsRegisteredProperty = DependencyProperty.RegisterAttached("IsRegistered", typeof(bool), typeof(DialogServiceViews), new PropertyMetadata(false, IsRegisteredChanged));



        public static bool GetIsRegistered(DependencyObject target)
        {
            return (bool)target.GetValue(IsRegisteredProperty);
        }

        public static void SetIsRegistered(DependencyObject target, bool value)
        {
            target.SetValue(IsRegisteredProperty, value);
        }


        #endregion

        #region Event Handler
        internal static void IsRegisteredChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(target))
                return;

            if (target is FrameworkElement view)
            {
                if ((bool)e.NewValue)
                {
                    Register(new ViewWrapper(view));
                }
                else
                {
                    Unregister(new ViewWrapper(view));

                }
            }
        }

        internal static void OwnerClosed(object? sender, EventArgs e)
        {
            if (sender is Window owner)
            {
                // Find views acting within closed window
                IView[] windowViews = Views.Where(view => ReferenceEquals(view.GetOwner(), owner)).ToArray();

                // Unregister Views in window
                foreach (IView windowView in windowViews)
                {
                    Unregister(windowView);
                }
            }
        }

        internal static void LaterRegister(object sender, RoutedEventArgs e)
        {
            if(e.Source is FrameworkElement frameworkElement)
            {
                //frameworkElement.Loaded -= LaterRegister;

                if(frameworkElement is IView view)
                {
                    Register(view);
                }
                else
                {
                    Register(new ViewWrapper(frameworkElement));
                }
            }
        }

        #endregion

        #region Property
        internal static IEnumerable<IView> Views => InternalViews.Where(view => view.IsAlive).ToArray();
        #endregion

        #region Function
        internal static void Register(IView view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));

            Window owner = view.GetOwner() as Window;

            if(owner == null)
            {
                var frameworkElement = view.Source as FrameworkElement;
                frameworkElement.Loaded -= LaterRegister;
                frameworkElement.Loaded += LaterRegister;
                return;
            }

            PruneInternalViews();

            owner.Closed -= OwnerClosed;
            owner.Closed += OwnerClosed;

            if (InternalViews.Count((_view) => _view.Source == view.Source) == 0)
            {
                InternalViews.Add(view);
            }

        }

        internal static void PruneInternalViews()
        {
            InternalViews.RemoveAll(reference => !reference.IsAlive);
        }

        internal static void Unregister(IView view)
        {
            if(view == null) throw new ArgumentNullException(nameof(view));

            PruneInternalViews();
            InternalViews.RemoveAll(registeredView => ReferenceEquals(registeredView.Source, view.Source));
        }

        #endregion

    }
}

