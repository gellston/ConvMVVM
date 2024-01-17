using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.WPF.Service.EnumStateManager
{
    public class EnumStateObject : INotifyPropertyChanged
    {
        #region Private Property
        private static EnumStateObject instance = null;
        private Dictionary<string, string> stateMap = new Dictionary<string, string>();       
        #endregion

        #region Event
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Static Property
        public static EnumStateObject Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnumStateObject();

                }
                return instance;
            }
        }
        #endregion

        #region Public Property

        public string this[string key]
        {

            get
            {
                if (!this.stateMap.ContainsKey(key))
                    return "";
                else return this.stateMap[key];
                
            }
        }

        public void ChangeState(string key, string value)
        {
            if(!this.stateMap.ContainsKey(key))
            {
                this.stateMap.Add(key, value);
            }

            this.stateMap[key] = value;

            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(""));
        }

        public void ChangeState<T>(T state) where T : Enum
        {
            try
            {
                var value = Enum.GetName(typeof(T), state);
                var nameSpace = (typeof(T)).ToString();
                this.ChangeState(nameSpace, value);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
