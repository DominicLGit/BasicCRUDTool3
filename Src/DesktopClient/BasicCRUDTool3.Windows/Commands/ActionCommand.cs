using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BasicCRUDTool3.Windows.Commands
{
    public class ActionCommand :ICommand
    {
        private readonly Action<Object> action;
        private readonly Predicate<Object> predicate;

        public ActionCommand(Action<Object> action) : this(action,null)
        {

        }

        public ActionCommand(Action<Object> action, Predicate<Object> predicate)
        {
            this.action = action ?? throw new ArgumentNullException("action", "You must specify an Actioni<T>.");
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (predicate == null)
            {
                return true;
            }
            return predicate(parameter);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }
    }
}
