using ConvMVVM.Core.Service.TranslateService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvMVVM.WPF.Service.ResourceContainer;

namespace ConvMVVM.WPF.Service.TranslateService
{
    internal class TranslateService : ITranslateService
    {
        #region Private Property
        private readonly IResourceContainer containerService = ResourceContainer.ResourceContainer.Instance;
        #endregion

        #region Constructor
        internal TranslateService()
        {

        }
        #endregion

        #region Property
        public string this[string key]
        {

            get
            {
                if (this.containerService.ResourceManager == null)
                {
                    return $"[{key}]";
                }

                if (this.containerService.CurrentCulture == null)
                {
                    return $"[{key}]";
                }

                var res = this.containerService.ResourceManager.GetString(key, this.containerService.CurrentCulture);
                return !string.IsNullOrWhiteSpace(res) ? res : $"[{key}]";
            }
        }
        #endregion

    }
}
