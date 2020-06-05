using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantApp.Logic_Layer.Commands
{
    class CommandHandler : ICommand
    {
        private Action<object> _actionParam;
        private Action _action;
        private Func<bool> _canExecute;

        public CommandHandler(Action<object> actionParam, Func<bool> canExecute)
        {
            _actionParam = actionParam;
            _canExecute = canExecute;
        }

        public CommandHandler(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            if (_actionParam != null)
            {
                _actionParam(parameter);
                return;
            }

            if (_action != null)
            {
                _action();
                return;
            }
        }
    }
}
