using System.Windows.Input;

namespace MVVMBase.Commands;

public class ActionCommand<T> : ICommand
{
    private readonly Predicate<T?>? canExecute;
    private readonly Action<T?>? execute;

    public ActionCommand(Action<T?> execute, Predicate<T?>? canExecute = null)
    {
        this.canExecute = canExecute;
        this.execute = execute;
    }

    public bool CanExecute(object? parameter) => canExecute?.Invoke((T?)parameter) ?? true;

    public void Execute(object? parameter) => execute?.Invoke((T?)parameter);

    public void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? CanExecuteChanged;
}