namespace MonkeyFinder.ViewModel;

public class BaseViewModel : INotifyPropertyChanged
{
    bool isBusy;
    string title;

    public event PropertyChangedEventHandler PropertyChanged;

    public bool IsBusy 
    {
        get => isBusy;
        set
        {
            if (isBusy.Equals(value)) return;

            isBusy = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsNotBusy));
        }
    }

    public string Title
    {
        get => title;
        set
        {
            if (title.Equals(value)) return;

            title = value;
            OnPropertyChanged();
        }
    }

    public bool IsNotBusy => !IsBusy;

    public void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
