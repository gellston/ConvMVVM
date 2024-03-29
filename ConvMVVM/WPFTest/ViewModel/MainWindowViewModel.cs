﻿using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using ConvMVVM.Core.Service.DialogService;
using ConvMVVM.WPF.Service.EnumStateManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTest.ViewModel
{
    partial class MainWindowViewModel : NotifyObject
    {
        #region Private Property
        private readonly IDialogService dialogService;
        private readonly IEnumStateManager enumStateManager;
        private readonly Func<object[], AViewModel> aviewModelFactory;
        #endregion

        #region Constructor
        public MainWindowViewModel(IDialogService _dialogService,
                                   IEnumStateManager _enumStateManager,
                                   Func<object[], AViewModel> _aviewModelFactory) { 
        
            this.dialogService = _dialogService;
            this.enumStateManager = _enumStateManager;

            this.aviewModelFactory = _aviewModelFactory;

  

        }
        #endregion

        #region Private Functions
        private AViewModel CreateAViewModel(params object[] parameters)
        {
            return this.aviewModelFactory(parameters);
        }

        #endregion

        #region Command


        [Property]
        private bool _TestA = false;



        [RelayCommand]
        private void Test()
        {
            Enum.TestEnum test = Enum.TestEnum.OK;
            this.enumStateManager.ChangeState(test);
        }

        #endregion
    }
}
