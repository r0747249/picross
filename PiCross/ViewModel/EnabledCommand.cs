using System;
using System.Windows.Input;

namespace ViewModel
{
    public class EnabledCommand : ICommand
    {
        private readonly Action action;

        public EnabledCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
