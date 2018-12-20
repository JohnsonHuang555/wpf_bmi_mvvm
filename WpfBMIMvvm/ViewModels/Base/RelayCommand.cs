using System;
using System.Windows.Input;

namespace AceEventApplication
{
    public class RelayCommand : ICommand
    {
        readonly Func<bool> _canExecute;
        readonly Action _execute;

        public RelayCommand(Action execute)
            : this(execute, null)
        {

        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
