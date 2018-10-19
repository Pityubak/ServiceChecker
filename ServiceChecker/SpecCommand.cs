using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServiceChecker
{
    class SpecCommand : ICommand
    {
        Action action;
        Func<bool> func;

        public SpecCommand(Action action)
        {
            this.action = action;
        }

        public SpecCommand(Action action, Func<bool> func)
        {
            this.action = action;
            this.func = func;
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
                return func();
        }

        public void Execute(object parameter)
        {
            action?.Invoke();
        }
    }
}
