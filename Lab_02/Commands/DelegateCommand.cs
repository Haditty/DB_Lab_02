using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_02.Commands
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public DelegateCommand(Action<object> execute, Func<object?, bool>? canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(execute);
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object? parameter)
        {
            return canExecute is null ? true : canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this,EventArgs.Empty);
    }
}
