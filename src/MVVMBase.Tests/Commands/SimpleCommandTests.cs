using System.ComponentModel;
using System.Windows.Input;
using MVVMBase.Commands;

namespace MVVMBase.Tests.Commands;

public class SimpleCommandTests
{
    [Fact]
    public void Execute_a_command()
    {
        var fired = false;
        void TestMethod()
        {
            fired = true;
        }
        var command = new SimpleCommand(TestMethod);
        Assert.IsAssignableFrom<ICommand>(command);
        command.Execute(null);
        Assert.True(fired);
    }
    [Fact]
    public void CanExecute_a_command()
    {
        void TestMethod() { }
        var command = new SimpleCommand(TestMethod);
        Assert.IsAssignableFrom<ICommand>(command);
        var canExecute = command.CanExecute(5);
        Assert.True(canExecute);
    }
}