using CommunityToolkit.Mvvm.ComponentModel;

namespace EnviTech.ViewModel
{
    public abstract partial class BaseViewModel : ObservableObject
    {

    }

    //public abstract partial class BaseViewModel : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }

    //}
}
