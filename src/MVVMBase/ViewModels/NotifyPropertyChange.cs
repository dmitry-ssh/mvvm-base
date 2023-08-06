using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVMBase.Annotations;

namespace MVVMBase.ViewModels;

public class NotifyPropertyChange : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}