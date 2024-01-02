using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.Service.DialogService
{
    public interface IModalDialogViewModel
    {

        public bool DialogResult { get; }

        public string Title { get; set; }
    }
}
