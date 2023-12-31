
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConvMVVM.Core.Component
{
    public class NotifyObject : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Public Property
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NotifyAll()
        {
            this.OnPropertyChanged("");
        }

        public void Property<T>(ref T reference, T value, [CallerMemberName]string propertyName = "")
        {
            if (!reference.Equals(value))
            {
                reference = value;
                OnPropertyChanged(propertyName);
            }
        }
        #endregion
    }
}
