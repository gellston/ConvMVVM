using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.WPF.Service.ResourceContainer
{
    public interface IResourceContainer
    {
        public CultureInfo CurrentCulture
        {
            get; set;
        }

        public ResourceManager ResourceManager
        {
            get; set;
        }

        public string CultureName
        {
            get;
        }


        public void ChangeCulture(string cultureName);

        public void ChangeResourceManager(ResourceManager resourceManager);

    }

}
