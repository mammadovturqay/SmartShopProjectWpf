using System;
using System.Windows.Input;

namespace SmartShopProject.Commands
{
    internal class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> executeMyCommand, Func<object, bool> canExecuteMyCommand)
        {
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}