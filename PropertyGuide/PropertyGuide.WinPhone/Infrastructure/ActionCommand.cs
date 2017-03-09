using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PropertyGuide.WinPhone.ViewModels
{
    public class ActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action _action;
        private readonly Func<bool>
        _canExecuteAction;

        public ActionCommand(Action action, Func<bool> canExecuteAction)
        {
            _action = action;
            _canExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteAction();
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
