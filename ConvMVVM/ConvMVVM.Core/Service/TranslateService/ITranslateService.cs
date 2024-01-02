using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.Service.TranslateService
{
    public interface ITranslateService
    {

        public string this[string key] { get; }
    }
}
