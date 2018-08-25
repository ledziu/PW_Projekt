using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Sledz.Guitars.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;
        public RelayCommand(Action<object> action)
        {
            _execute = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(_canExecute != null)
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
