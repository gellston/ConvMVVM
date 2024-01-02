using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Service.DialogService;
using ConvMVVM.Core.Service.RegionManager;
using ConvMVVM.Core.Service.TranslateService;
using ConvMVVM.WPF.Service.ResourceContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTest.ViewModel
{
    partial class MainWindowViewModel : NotifyObject
    {
        #region Private Property
        private readonly IDialogService dialogService;
        private readonly IRegionManager regionManager;
        private readonly ITranslateService translateService;
        private readonly IResourceContainer resourceContainer;

        private readonly AWindowViewModel aWindowViewModel;
        private readonly AViewModel aViewModel;
        #endregion

        #region Constructor
        public MainWindowViewModel(AWindowViewModel _aWindowViewModel,
                                   AViewModel _aViewModel,
                                   IDialogService dialogService,
                                   IRegionManager regionManager,
                                   ITranslateService translateService,
                                   IResourceContainer resourceContainer)
        {

            this.aWindowViewModel = _aWindowViewModel;
            this.aViewModel = _aViewModel;


            this.translateService = translateService;
            this.dialogService = dialogService;
            this.regionManager = regionManager;
            this.resourceContainer = resourceContainer;
        }
        #endregion


        #region Command

        [RelayCommand]
        public void Loaded(object eventArg)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("test");
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }

        [RelayCommand]
        public void Test()
        {
            try
            {

     
                

            }catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }




        [AsyncRelayCommand]
        private async Task Run()
        {
            await Task.Delay(10000);
        }

        #endregion
    }
}
