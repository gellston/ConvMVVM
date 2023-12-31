﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.WPF.Service.ResourceContainer
{
    public class ResourceContainer : INotifyPropertyChanged, IResourceContainer
    {

        #region Private Property
        private CultureInfo _CurrentCulture = null;
        private ResourceManager _ResourceManager = null;
        #endregion


        #region Event
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion


        #region Singleton Instance 
        private static readonly ResourceContainer instance = new ResourceContainer();
        public static ResourceContainer Instance
        {
            get => instance;
        }
        #endregion


        #region Constructor
        internal ResourceContainer()
        {

        }
        #endregion


        #region Property
        public CultureInfo CurrentCulture
        {
            get => _CurrentCulture;
            set
            {
                if (_CurrentCulture != value)
                {
                    _CurrentCulture = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(string.Empty));
                    }
                }
            }
        }

        public ResourceManager ResourceManager
        {
            get => _ResourceManager;
            set
            {
                if (_ResourceManager != value)
                {
                    _ResourceManager = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(string.Empty));
                    }
                }
            }
        }

        public string CultureName
        {
            get
            {
                if (CurrentCulture == null)
                    return "None";

                return CurrentCulture.Name;
            }
        }


        public string this[string key]
        {

            get
            {
                if (this.ResourceManager == null)
                {
                    return $"[{key}]";
                }

                if (this.CurrentCulture == null)
                {
                    return $"[{key}]";
                }

                var res = this.ResourceManager.GetString(key, this.CurrentCulture);
                return !string.IsNullOrWhiteSpace(res) ? res : $"[{key}]";
            }
        }

        #endregion


        #region Functions
        public void ChangeCulture(string cultureName)
        {
            CurrentCulture = new CultureInfo(cultureName);
        }

        public void ChangeResourceManager(ResourceManager resourceManager)
        {
            ResourceManager = resourceManager;
        }
        #endregion


    }
}
