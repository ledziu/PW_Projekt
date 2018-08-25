using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Sledz.Guitars.Wpf.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public RelayCommand(Action<object> p) : this(p, null)
        {
        }

        public RelayCommand(Action<object> action, object p)
        {
            _execute = action;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canexecute)
        {
            _execute = execute;
            _canExecute = canexecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
            {
                _execute(parameter);
            }
        }


    }
}
