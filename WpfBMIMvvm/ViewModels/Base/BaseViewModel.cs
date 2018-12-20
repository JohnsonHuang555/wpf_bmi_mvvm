using System.ComponentModel;

namespace AceEventApplication
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

    }
}
