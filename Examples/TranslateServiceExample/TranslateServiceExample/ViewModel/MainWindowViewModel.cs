using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using ConvMVVM.Core.Service.TranslateService;
using ConvMVVM.WPF.Service.ResourceContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateServiceExample.ViewModel
{
    partial class MainWindowViewModel : NotifyObject
    {

        #region Private Property
        private readonly ITranslateService translateService;
        private readonly IResourceContainer resourceContainer;
        #endregion

        #region Constructor
        public MainWindowViewModel(ITranslateService translateService,
                                   IResourceContainer resourceContainer) { 
        
            this.translateService = translateService;
            this.resourceContainer = resourceContainer;
        }
        #endregion

        #region Command
        [RelayCommand]
        private void Test()
        {
            try
            {
                if(this.resourceContainer.CultureName == "en")
                {
                    this.resourceContainer.ChangeCulture("kr");
                }
                else
                {
                    this.resourceContainer.ChangeCulture("en");
                }
                System.Diagnostics.Debug.WriteLine(this.translateService["TestContent"]);
                System.Diagnostics.Debug.WriteLine(this.translateService["Language"]);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
