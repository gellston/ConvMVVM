using ConvMVVM.WPF.Service.RegionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ConvMVVM.WPF.Template
{
    public class AutoViewTemplateSelector : DataTemplateSelector
    {

        public string DataSuffix { get; set; } = "ViewModel";
        public string ViewSuffix { get; set; } = "View";
        public string Fallback { get; set; } = "FallbackView";

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            try
            {
                if(item != null)
                {

                    var viewModelName = item.GetType().Name;
                    var viewName = viewModelName.Replace(DataSuffix, ViewSuffix);
                    var viewType = ViewTypeStorage.NoneCacheView(viewName);
                    if(viewType != null)
                    {
                        return new DataTemplate()
                        {
                            VisualTree = new FrameworkElementFactory(viewType)
                        };
                    }
                    else
                    {
                        if (Fallback != "")
                        {
                            var fallbackView = ViewTypeStorage.NoneCacheView(Fallback);
                            if(fallbackView != null)
                            {
                                return new DataTemplate()
                                {
                                    VisualTree = new FrameworkElementFactory(fallbackView)
                                };
                            }
                    
                        }
                    }
                }
            }catch (Exception ex)
            {
                
            }
            return base.SelectTemplate(item, container);
        }
    }
}
