using System;
using System.Windows.Input;

namespace PriceBookApp.Helpers
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute; // Make it nullable
        private readonly Func<object?, bool>? _canExecute; // Make it nullable

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) // Make it nullable
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter) // Make it nullable
        {
            _execute(parameter);
        }

        public event EventHandler? CanExecuteChanged // Make it nullable
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
