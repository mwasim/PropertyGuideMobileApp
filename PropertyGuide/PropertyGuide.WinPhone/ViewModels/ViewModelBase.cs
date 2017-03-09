using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PropertyGuide.WinPhone
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsDataLoaded
        {
            get;
            protected set;
        }

        public virtual void LoadData() { }
    }
}
