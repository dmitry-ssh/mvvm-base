using System.ComponentModel;
using MVVMBase.ViewModels;

namespace MVVMBase.Tests.ViewModels;

public class ViewModelBaseTests
{
    [Fact]
    public void ViewModelBase_implements_INotifyPropertyChanged()
    {
        var vm = new ViewModelBase();
        Assert.IsAssignableFrom<INotifyPropertyChanged>(vm);
    }
}